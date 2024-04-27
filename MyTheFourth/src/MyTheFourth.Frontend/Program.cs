using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyTheFourth.Frontend;
using MyTheFourth.Frontend.Configuration;
using MyTheFourth.Frontend.Constants;
using MyTheFourth.Frontend.DependencyInjections;
using MyTheFourth.Frontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var backendSection = builder.Configuration.GetSection("Backend").Get<IEnumerable<ApiConfiguration>>();

if (backendSection is not null)
    foreach (var backend in backendSection)
    {
        builder.Services.AddSingleton(backend);
    }

builder.Services.AddSingleton<IApiConfigurationServiceCollection, ApiConfigurationServiceCollection>();

builder.Services.AddTransient<MyTheFourthHttpServiceFake>();
builder.Services.AddTransient<MyTheFourthHttpServiceFake2>();

builder.Services.AddBackendProviders(
    config =>
{
    config.RegistryService<MyTheFourthHttpServiceFake>();
    config.RegistryService<MyTheFourthHttpServiceFake2>();
    config.WithDefaultService(BackendServicesIdentifiers.Faker);
}
);

builder.Services.AddBlazorBootstrap();

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

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
