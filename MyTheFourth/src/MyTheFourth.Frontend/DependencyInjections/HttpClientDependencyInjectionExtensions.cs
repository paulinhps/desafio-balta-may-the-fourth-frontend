using Blazored.LocalStorage;
using MyTheFourth.Frontend.Services;
using MyTheFourth.Frontend.Services.Interfaces;

namespace MyTheFourth.Frontend.DependencyInjections;

public static class HttpClientDependencyInjectionExtensions
{
    public static IServiceCollection AddBackendProviders(this IServiceCollection services)
    {
        // configura injeção do provider de serviço de api
        services.AddSingleton<IApiHttpServiceProvider, ApiHttpServiceProvider>();

        // identifica todas as implementações de apis
        // TODO: fazer o filtro com o que for parametrizado
        var implementationType = typeof(IMyTheFourthService);

        services.AddApiService<MyTheFourthHttpServiceFake>();
        services.AddApiService<MyTheFourthHttpServiceFake2>();


        // registrar todo os serviços implementados da interface IMyTheFourthService
        

        // registra injeção de interfaces segregadas
        var interfaces = implementationType.GetInterfaces();

        foreach (var type in interfaces)
        {
            services.AddTransient(type, provider => {

    var service = provider.GetRequiredService<IApiHttpServiceProvider>().Current!;
                return service;
            });
        }


        return services;
    }

    public static IServiceCollection AddApiService<TImplementation>(this IServiceCollection services) where TImplementation: IMyTheFourthService 
    => services.AddTransient(
        typeof(IMyTheFourthService), 
        provider => provider.GetRequiredService<TImplementation>());

}

public class ApiHttpServiceProvider : IApiHttpServiceProvider {
    private readonly IServiceProvider _serviceProvider;
    private string _currentServiceId = null!;


    public ApiHttpServiceProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IMyTheFourthService? Current => GetCurrentService();

    private IMyTheFourthService? GetCurrentService()
    {
        var apiServices = _serviceProvider.GetServices<IMyTheFourthService>();

        if(string.IsNullOrEmpty(_currentServiceId)) return apiServices.FirstOrDefault();

        return apiServices.FirstOrDefault(c => c.ServiceId.ToString().Equals(_currentServiceId));

    }

    public void SetDefault()
    {
         var apiServices = _serviceProvider.GetServices<IMyTheFourthService>();
        
        if(apiServices.Any()) _currentServiceId = apiServices.First().ServiceId.ToString();
    }

    public void SetServiceId(string serviceId)
    {
        if(string.IsNullOrEmpty(serviceId)) return;
        _currentServiceId = serviceId;
       
    }
}

public interface IApiHttpServiceProvider
{
    IMyTheFourthService? Current {get;}
    void SetServiceId(string serviceId);
    void SetDefault();


}