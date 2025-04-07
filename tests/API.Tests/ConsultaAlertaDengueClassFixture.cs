using System.Net.Http.Json;

namespace WebApp.Test;

public class ConsultaAlertaDengueClassFixture : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public ConsultaAlertaDengueClassFixture(CustomWebApplicationFactory factory)
        => _httpClient = factory.CreateClient();

    protected async Task<HttpResponseMessage> PostAsync(string method, object result)
    {
        return await _httpClient.PostAsJsonAsync(method, result);
    }

    protected async Task<HttpResponseMessage> GetAsync(string method)
    {
        return await _httpClient.GetAsync(method);
    }
}
