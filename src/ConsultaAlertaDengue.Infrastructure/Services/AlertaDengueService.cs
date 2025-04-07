using ConsultaAlertaDengue.Domain.Entities;
using ConsultaAlertaDengue.Domain.Services;
using ConsultaAlertaDengue.Domain.ValueObjects;
using ConsultaAlertaDengue.Infrastructure.DataAccess;
using System.Globalization;
using System.Text.Json;

namespace ConsultaAlertaDengue.Infrastructure.Services;

public class AlertaDengueService : IAlertaDengueService
{
    private readonly JsonSerializerOptions _options;
    private readonly IHttpClientFactory _clientFactory;
    private readonly ConsultaAlertaDengueDbContext _context;

    public AlertaDengueService(IHttpClientFactory clientFactory, ConsultaAlertaDengueDbContext context)
    {
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _clientFactory = clientFactory;
        _context = context;
    }

    public async Task<(bool, string)> AtualizaDadosDengueAsync()
    {
        var dadosDengue = _context.DadosDengue.ToList();

        if (dadosDengue.Count > 0)
        {
            _context.DadosDengue.RemoveRange(dadosDengue);
            await _context.SaveChangesAsync();
        }        

        string urlApi = GerarUrl();

        var client = _clientFactory.CreateClient("AlertaDengueApi");

        using var response = await client.GetAsync(urlApi);

        if (!response.IsSuccessStatusCode)
        {
            return (false, $"Erro ao acessar a API, pois apresentou um erro com StatusCode {response.StatusCode}");
        }

        var content = await response.Content.ReadAsStreamAsync();

        if (content is null)
        {
            return (false, "Conteúdo da resposta da API é nulo.");
        }

        var novosDadosDengue = JsonSerializer.Deserialize<List<DadosDengue>>(content, _options);

        if (novosDadosDengue is null)
        {
            return (false, "Falha ao desserializar os dados da API.");
        }

        _context.DadosDengue.AddRange(novosDadosDengue);

        var success = await _context.SaveChangesAsync();

        if (success <= 0)
        {
            return (false, "Falha ao salvar os dados no banco de dados.");
        }

        return (true, "Dados atualizados com sucesso.");

    }

    //Método para gerar a URL da API com os valores dos parâmetros de acordo com o requisito
    private string GerarUrl()
    {   
        var culture = CultureInfo.CurrentCulture;
        var calendar = culture.Calendar;
        var weekRule = culture.DateTimeFormat.CalendarWeekRule;
        var firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;

        var numeroUltimosMeses = ConsultaAlertaDengueRulesConstant.NUMERO_ULTIMOS_MESES_ALERTA_DENGUE;

        var semanaInicio = calendar.GetWeekOfYear(DateTime.Today, weekRule, firstDayOfWeek);
        var anoInicio = calendar.GetYear(DateTime.Today.AddMonths(-numeroUltimosMeses));

        var semanaFim = calendar.GetWeekOfYear(DateTime.Today.AddMonths(-numeroUltimosMeses), weekRule, firstDayOfWeek);
        var anoFim = DateTime.Now.Year;

        var geocode = ConsultaAlertaDengueRulesConstant.GEOCODE;

        var url = $"https://info.dengue.mat.br/api/alertcity?geocode={geocode}&disease=dengue&format=json&ew_start={semanaInicio}&ew_end={semanaFim}&ey_start={anoInicio}&ey_end={anoFim}";

        return url;
    }
}
