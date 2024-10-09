using Blazored.LocalStorage; // Ensure you have this
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


using blazorblog;
using blazorblog.Services; // Ensure this includes your services

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
// Add root component
builder.RootComponents.Add<App>("#app");

// Log the loaded base URL
var baseUrl = builder.Configuration["Api:BaseUrl"];
Console.WriteLine($"Loaded Base URL: {baseUrl}");

// Register HttpClient for API requests
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register local storage service
builder.Services.AddBlazoredLocalStorage();

// Register custom AuthenticationStateProvider
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

// Register your services
builder.Services.AddScoped<PizzaService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CheckoutService>();

// Register the AuthService
builder.Services.AddScoped<AuthService>();

// Register authorization services
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("role", "admin"));
});

// Add configuration from appsettings.json
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

await builder.Build().RunAsync();
