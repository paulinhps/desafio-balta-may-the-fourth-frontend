namespace MyTheFourth.Frontend.Configuration;

public interface IApiConfigurationServiceCollection
{
    ApiConfiguration GetConfiguration(string serviceId);
    IEnumerable<ApiConfiguration> ListAllowedBackends();
}
