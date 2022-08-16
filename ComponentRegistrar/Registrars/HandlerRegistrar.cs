using Contracts.Birthdays.GetBirthdays;
using Handlers.GetBirthdays;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Register.Registrars;

public static class HandlerRegistrar
{
    public static IServiceCollection AddHandlerService(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ApiRegistrar));
        
        services.AddTransient<IRequestHandler<GetBirthdaysQuery, GetBirthdaysResponse>, GetBirthdaysHandler>();
        
        return services;
    }
}