using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using blazorblog.Models;
using Microsoft.Extensions.Configuration;

namespace blazorblog.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["Api:BaseUrl"];
        }

        // Fetch all products
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>($"{_apiBaseUrl}/api/Products");
        }

        // Fetch a single product by ID
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"{_apiBaseUrl}/api/Products/{id}");
        }
    }
}
