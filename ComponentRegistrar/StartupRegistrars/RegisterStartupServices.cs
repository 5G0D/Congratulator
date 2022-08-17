using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Register.Registrars;

public static class RegisterStartupServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        ConfigurationManager configuration = builder.Configuration;
        IWebHostEnvironment environment = builder.Environment;

        builder.Services.AddApiServices()
            .AddDataAccessServices(configuration, environment)
            .AddAutoMapperService()
            .AddAppServices()
            .AddHandlerService();
        
        return builder;
    }
}

