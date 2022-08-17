using Contracts.Humans.CreateHuman;
using Contracts.Humans.DeleteHuman;
using Contracts.Humans.GetHumans;
using Contracts.Humans.UpdateHuman;
using Handlers.CreateHuman;
using Handlers.DeleteHuman;
using Handlers.GetHumans;
using Handlers.UpdateHuman;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Register.Registrars;

public static class HandlerRegistrar
{
    public static IServiceCollection AddHandlerService(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ApiRegistrar));
        
        services.AddTransient<IRequestHandler<GetHumansQuery, GetHumansResponse>, GetHumansHandler>();
        services.AddTransient<IRequestHandler<CreateHumanCommand, CreateHumanResponse>, CreateHumanHandler>();
        services.AddTransient<IRequestHandler<DeleteHumanCommand, DeleteHumanResponse>, DeleteHumanHandler>();
        services.AddTransient<IRequestHandler<UpdateHumanCommand, UpdateHumanResponse>, UpdateHumanHandler>();
        
        return services;
    }
}