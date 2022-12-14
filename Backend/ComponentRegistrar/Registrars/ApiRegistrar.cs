using Microsoft.Extensions.DependencyInjection;

namespace Register.Registrars;

public static class ApiRegistrar
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}