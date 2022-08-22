using Microsoft.AspNetCore.Server.Kestrel.Core;
using Register.Registrars;
using Register.StartupRegistrars;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build()
    .SetupMiddleware()
    .Run();