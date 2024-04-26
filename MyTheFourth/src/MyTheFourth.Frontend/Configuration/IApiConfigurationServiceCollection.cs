namespace MyTheFourth.Frontend.Configuration;

public interface IApiConfigurationServiceCollection
{
    IEnumerable<ApiConfiguration> ListAllowedBackends();
}
