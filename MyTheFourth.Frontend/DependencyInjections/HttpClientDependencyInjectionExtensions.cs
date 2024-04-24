using MyTheFourth.Frontend.Services;

namespace MyTheFourth.Frontend.DependencyInjections;

public static class HttpClientDependencyInjectionExtensions
{
    public static IServiceCollection AddApiHttpServiceFake(this IServiceCollection services)
    {
        services.AddScoped<MyTheFourthHttpServiceFake>();

        var implementationType = typeof(MyTheFourthHttpServiceFake);

        var interfaces = implementationType.GetInterfaces();

        foreach (var type in interfaces)
        {
            services.AddTransient(type, provider => provider.GetRequiredService<MyTheFourthHttpServiceFake>());
        }


        return services;
    }


}