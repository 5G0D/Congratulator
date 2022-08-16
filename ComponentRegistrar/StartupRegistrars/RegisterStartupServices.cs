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
        
        builder.Services.AddApiServices();
        builder.Services.AddDataAccessServices(configuration, environment);
        builder.Services.AddAutoMapperService();
        builder.Services.AddAppServices();
        builder.Services.AddHandlerService();
        
        return builder;
    }
}

