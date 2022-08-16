using Microsoft.Extensions.DependencyInjection;

namespace Register.Registrars;

public static class ApiRegistrar
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}