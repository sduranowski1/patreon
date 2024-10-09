using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using blazorblog.Models;
using Microsoft.Extensions.Configuration;

namespace blazorblog.Services
{
    public class PizzaService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;


    public PizzaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiBaseUrl = configuration["Api:BaseUrl"];
    }

    public async Task<List<Pizza>> GetPizzasAsync()
    {
        // return await _httpClient.GetFromJsonAsync<List<Pizza>>("https://localhost:7154/api/Pizzas");
        return await _httpClient.GetFromJsonAsync<List<Pizza>>($"{_apiBaseUrl}/api/Pizzas");
    }
}

}
