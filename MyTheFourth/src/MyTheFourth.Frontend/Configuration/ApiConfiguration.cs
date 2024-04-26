public class ApiConfiguration
{
    public string ServiceId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string  BaseAddress { get; set; } = null!;
    public bool AllowCrud { get; set; }
}


public interface IApiConfigurationServiceCollection {
    IEnumerable<ApiConfiguration> ListAllowedBackends();
}

public class ApiConfigurationServiceCollection : IApiConfigurationServiceCollection {
    private readonly IServiceProvider _serviceProvider;

    public ApiConfigurationServiceCollection(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IEnumerable<ApiConfiguration> ListAllowedBackends() 
    => _serviceProvider.GetServices<ApiConfiguration>() ?? Array.Empty<ApiConfiguration>();
}
