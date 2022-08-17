using Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Register.Configurators;

public static class ExceptionHandlingConfigurator
{
    public static void UseExceptionHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}