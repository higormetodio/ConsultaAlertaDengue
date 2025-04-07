using ConsultaAlertaDengue.Application.Models;
using ConsultaAlertaDengue.Domain.Entities;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using WebApp.Test;

namespace API.Tests.Controllers;

public class GetDadosDengueBySeAnoTest : ConsultaAlertaDengueClassFixture
{
    public const string METHOD = "dadosdengue";
    public readonly DadosDengue _dadosDengue;
    public GetDadosDengueBySeAnoTest(CustomWebApplicationFactory factory) : base(factory)
    {
        _dadosDengue = factory.GetDadosDengue();
    }

    [Fact]
    public async Task Success()
    {
        var response = await GetAsync($"{METHOD}/?semana=52&ano=2025");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        await using var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(responseBody);

        responseData.RootElement.GetProperty("semanaEpidemiologica").GetInt32().Should().Be(_dadosDengue.SemanaEpidemiologica);
        responseData.RootElement.GetProperty("casosEstimados").GetDouble().Should().Be(_dadosDengue.CasosEstimados);
        responseData.RootElement.GetProperty("casosNotificados").GetInt64().Should().Be(_dadosDengue.CasosNotificados);
        responseData.RootElement.GetProperty("nivelAlerta").GetInt32().Should().Be((int)_dadosDengue.NivelAlerta);
    }

    [Fact]
    public async Task Error_Dados_Dengue_Not_Found()
    {
        var response = await GetAsync($"{METHOD}?semana=12&ano=2024");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        await using var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = JsonSerializer.Deserialize<ResultViewModel<DadosDengue>>(responseBody, options);

        responseData.Should().NotBeNull();
        responseData!.IsSuccess.Should().BeFalse();
        responseData.Message.Should().Be("Dados de dengue não encontrados para a semana 12 do ano 2024");
    }


}
