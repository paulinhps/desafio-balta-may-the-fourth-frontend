namespace MyTheFourth.Frontend.Configuration;

public class ApiConfigurationServiceCollection : IApiConfigurationServiceCollection
{
    private readonly IServiceProvider _serviceProvider;

    public ApiConfigurationServiceCollection(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IEnumerable<ApiConfiguration> ListAllowedBackends()
    => _serviceProvider.GetServices<ApiConfiguration>() ?? Array.Empty<ApiConfiguration>();
}
