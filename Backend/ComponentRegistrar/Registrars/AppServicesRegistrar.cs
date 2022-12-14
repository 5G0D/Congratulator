using AppServices.Human.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Register.Registrars;

public static class AppServicesRegistrar
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IHumanService, HumanService>();
            
        return services;
    }
}