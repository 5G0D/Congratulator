using Contracts.Humans.GetHumans;
using Handlers.GetHumans;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Register.Registrars;

public static class HandlerRegistrar
{
    public static IServiceCollection AddHandlerService(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ApiRegistrar));
        
        services.AddTransient<IRequestHandler<GetHumansQuery, GetHumansResponse>, GetHumansHandler>();
        
        return services;
    }
}