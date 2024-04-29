using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using System.Reflection;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyTheFourth.Frontend;
using MyTheFourth.Frontend.Configuration;
using MyTheFourth.Frontend.Constants;
using MyTheFourth.Frontend.DependencyInjections;
using MyTheFourth.Frontend.Services;
using DevResistence = MyTheFourth.Frontend.DevsResistenceContext;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IApiConfigurationServiceCollection, ApiConfigurationServiceCollection>();

builder.Services.AddTransient<MyTheFourthHttpServiceFake>();
builder.Services.AddTransient<MyTheFourthHttpServiceFake2>();

builder.AddBackendProviders(assemblies: Assembly.GetExecutingAssembly())
       .AddApi<DevResistence.Services.MyTheFourthHttpService>(BackendServicesIdentifiers.DevResistence);

builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddBlazorBootstrap();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();


public static class BackendApiServiceExtensions
{

    public static IBackendServiceConfigurationBuilder AddApi<TService>(this IBackendServiceConfigurationBuilder backendBuilder, string apiServiceId) where TService : class
    {

        return backendBuilder.AddHttpClient<TService>(apiServiceId);

    }
}

[Serializable]
internal class ApiConfigurationException : Exception
{
    public ApiConfigurationException()
    {
    }

    public ApiConfigurationException(string? message) : base(message)
    {
    }

    public ApiConfigurationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}