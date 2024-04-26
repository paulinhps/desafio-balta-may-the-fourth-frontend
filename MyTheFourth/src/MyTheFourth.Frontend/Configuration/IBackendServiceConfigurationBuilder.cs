using MyTheFourth.Frontend.Services.Interfaces;

namespace MyTheFourth.Frontend.Configuration;

public interface IBackendServiceConfigurationBuilder
{

    IBackendServiceConfigurationBuilder RegistryService<TImplementation>()
        where TImplementation : IMyTheFourthService;
    IBackendServiceConfigurationBuilder WithDefaultService(string serviceId);
}
