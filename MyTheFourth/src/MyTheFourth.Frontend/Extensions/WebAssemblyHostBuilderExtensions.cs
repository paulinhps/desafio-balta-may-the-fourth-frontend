using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using MyTheFourth.Frontend.Configuration;
using MyTheFourth.Frontend.Constants;
using MyTheFourth.Frontend.DependencyInjections;
using MyTheFourth.Frontend.Services;
using DevResistence = MyTheFourth.Frontend.DevsResistenceContext;
using RebelRenegades = MyTheFourth.Frontend.RebelRenegadesContext;

namespace MyTheFourth.Frontend.Extensions;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

public static class WebAssemblyHostBuilderExtensions
{
    private static WebAssemblyHostBuilder AddRootComponents(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        return builder;
    }

    private static WebAssemblyHostBuilder AddServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddSingleton<IApiConfigurationServiceCollection, ApiConfigurationServiceCollection>();
        builder.Services.AddTransient<MyTheFourthHttpServiceFake>();
        builder.Services.AddTransient<MyTheFourthHttpServiceFake2>();
        return builder;
    }

    private static WebAssemblyHostBuilder AddBackendProvidersAndApis(this WebAssemblyHostBuilder builder)
    {
        builder.AddBackendProviders(assemblies: Assembly.GetExecutingAssembly())
           .AddApi<DevResistence.Services.DevResistenceMyTheFourthHttpService>(
                BackendServicesIdentifiers.DevResistence)
           .AddApi<RebelRenegades.Services.RebelRenegadesMyTheFourthHttpService>(BackendServicesIdentifiers
               .RebelRenegades);
        return builder;
    }

    private static WebAssemblyHostBuilder ConfigureBlazoredLocalStorage(this WebAssemblyHostBuilder builder)
    {
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
        return builder;
    }

    private static WebAssemblyHostBuilder AddBlazorComponents(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddBlazorBootstrap();
        return builder;
    }

    private static WebAssemblyHostBuilder AddBreadcrumbServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddSingleton<IBreadcrumbItemService, BreadcrumbItemService>();
        builder.Services.AddSingleton<IBreadcrumbItemServiceEvents>(provider =>
            provider.GetRequiredService<IBreadcrumbItemService>());
        return builder;
    }

    private static WebAssemblyHostBuilder AddHttpClient(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        return builder;
    }

    public static WebAssemblyHostBuilder AddDefaultConfiguration(this WebAssemblyHostBuilder builder)
    {
        builder.AddRootComponents()
              .AddServices()
              .AddBackendProvidersAndApis()
              .ConfigureBlazoredLocalStorage()
              .AddBlazorComponents()
              .AddBreadcrumbServices()
              .AddHttpClient();
        return builder;
    }
}