using MyTheFourth.Frontend.DependencyInjections;
using MyTheFourth.Frontend.Services.Interfaces;

namespace MyTheFourth.Frontend.Configuration;

public class BackendServiceConfigurationBuilder : IBackendServiceConfigurationBuilder
{
    private IServiceCollection _services;
    private string _defaultServiceId = string.Empty;

    internal static BackendServiceConfigurationBuilder Create(IServiceCollection services)
     => new(services);

    private BackendServiceConfigurationBuilder(IServiceCollection services)
    {
        _services = services;
    }
    public IBackendServiceConfigurationBuilder RegistryService<TImplementation>() where TImplementation : IMyTheFourthService
    {
        AddApiService<TImplementation>();
        return this;
    }

    private void AddApiService<TImplementation>() where TImplementation : IMyTheFourthService
     => _services.AddTransient(
        typeof(IMyTheFourthService),
        provider => provider.GetRequiredService<TImplementation>());

    public IBackendServiceConfigurationBuilder WithDefaultService(string serviceId)
    {
        _defaultServiceId = serviceId;

        return this;
    }

    internal IBackendServiceConfigurationBuilder Build()
    {
        // configura injeção do provider de serviço de api
        _services.AddSingleton<IBackendServiceProvider>(provider =>
        {
            var serviceProvider = new ApiHttpServiceProvider(provider, _defaultServiceId);

            return serviceProvider;
        });

        // identifica todas as implementações de apis
        // TODO: fazer o filtro com o que for parametrizado
        var implementationType = typeof(IMyTheFourthService);



        // registrar todo os serviços implementados da interface IMyTheFourthService


        // registra injeção de interfaces segregadas
        var interfaces = implementationType.GetInterfaces();

        foreach (var type in interfaces)
        {
            _services.AddTransient(type, provider =>
            {

                var service = provider.GetRequiredService<IBackendServiceProvider>().Current!;
                return service;
            });
        }


        return this;
    }
}
