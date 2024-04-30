using MyTheFourth.Frontend.DependencyInjections;
using MyTheFourth.Frontend.Http.Handlers;
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
        AddApiService(typeof(TImplementation));

        return this;
    }

    private void AddApiService(Type implementationType)
     => _services.AddTransient(
        typeof(IMyTheFourthService),
        provider => provider.GetService(implementationType)!);

    public IBackendServiceConfigurationBuilder WithDefaultService(string serviceId)
    {
        _defaultServiceId = serviceId;

        return this;
    }

    internal IBackendServiceConfigurationBuilder Build()
    {

        _services.AddTransient<BackendHandler>();

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

    public IBackendServiceConfigurationBuilder RegistryServices(params Type[] servicesImplementationList)
    {
        try
        {
            foreach (var type in servicesImplementationList)
            {
                AddApiService(type);
            }
        }
        catch (Exception ex)
        {
            throw new ApiConfigurationException("an eror occour on registry backend api service", ex);
        }
        return this;
    }

    public IBackendServiceConfigurationBuilder AddHttpClient<TService>(string apiServiceId, Action<IServiceProvider, HttpClient>? configAction = null) where TService : class
    {
        _services.AddHttpClient<TService>((provider, httpClient) =>
        {
            var apiServiceConfiguration = provider.GetRequiredService<IApiConfigurationServiceCollection>();
            ApiConfiguration? apiConfiguration = apiServiceConfiguration?.GetConfiguration(apiServiceId);

            if (apiConfiguration == null) throw new ApiConfigurationException($"O Id de serviço {apiServiceId} não está configurado ou não existe");
            httpClient.BaseAddress = new Uri(apiConfiguration!.BaseAddress);

            configAction?.Invoke(provider, httpClient);
        })
        .AddHttpMessageHandler(provider => provider.GetService<BackendHandler>()!);

        return this;

    }
}
