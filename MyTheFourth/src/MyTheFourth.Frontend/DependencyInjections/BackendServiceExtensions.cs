using System.Reflection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyTheFourth.Frontend.Configuration;
using MyTheFourth.Frontend.Services.Interfaces;

namespace MyTheFourth.Frontend.DependencyInjections;

public static class BackendServiceExtensions
{
    public static IBackendServiceConfigurationBuilder AddBackendProviders(this IServiceCollection services, Action<IBackendServiceConfigurationBuilder> configAction)
    {

        var configBuilder = BackendServiceConfigurationBuilder.Create(services);

        configAction?.Invoke(configBuilder);

        configBuilder.Build();

        return configBuilder;
    }

    public static IBackendServiceConfigurationBuilder AddBackendProviders(this WebAssemblyHostBuilder builder, string backEndSectionName = "Backend", params Assembly[] assemblies)
    {

        if (assemblies == null) throw new ApiConfigurationException("This feature request one o more assemblies");

        var backendSection = builder.Configuration.GetSection(backEndSectionName).Get<IEnumerable<ApiConfiguration>>();

        if (backendSection is not null)
            foreach (var backend in backendSection)
            {
                builder.Services.AddSingleton(backend);
            }


        var serviceType = typeof(IMyTheFourthService);
        var servicesImplementationList = assemblies.SelectMany(assembly => assembly.GetTypes())
        .Where(serviceType.IsAssignableFrom)
        .ToArray();

        return builder.Services.AddBackendProviders(config =>
        {
            config.RegistryServices(servicesImplementationList);
        });
    }

}
