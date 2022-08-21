using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Register.Configurators;

namespace Register.Registrars;

public static class RegisterStartupMiddlewares
{
    public static WebApplication SetupMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.UseExceptionHandling();

        app.MapControllers();

        return app;
    }
}