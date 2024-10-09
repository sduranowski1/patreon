using blazorblog.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class CheckoutService
{
    private readonly HttpClient _httpClient;

    public CheckoutService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SubmitCheckoutForm(CheckoutFormModel model)
    {
        var response = await _httpClient.PostAsJsonAsync("/Checkout/create-checkout-session", model);
        response.EnsureSuccessStatusCode();
    }
}
