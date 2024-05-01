using MyTheFourth.Frontend.Services.Interfaces;

namespace MyTheFourth.Frontend.Configuration;

public interface IBackendServiceConfigurationBuilder
{

    IBackendServiceConfigurationBuilder RegistryService<TImplementation>()
        where TImplementation : IMyTheFourthService;
    IBackendServiceConfigurationBuilder RegistryServices(params Type[] servicesImplementationList);
    IBackendServiceConfigurationBuilder WithDefaultService(string serviceId);
    IBackendServiceConfigurationBuilder AddHttpClient<TService>(string apiServiceId, Action<IServiceProvider, HttpClient>? configAction = null) where TService : class;
}
