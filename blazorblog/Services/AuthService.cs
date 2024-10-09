using Blazored.LocalStorage;
using System.Threading.Tasks;

public class AuthService
{
    private readonly ILocalStorageService _localStorage;

    public AuthService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<bool> IsLoggedIn()
    {
        var token = await _localStorage.GetItemAsync<string>("token");
        return !string.IsNullOrEmpty(token);
    }

    public async Task SaveToken(string token)
    {
        await _localStorage.SetItemAsync("token", token);
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("token");
    }
}
