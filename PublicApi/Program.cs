using Register.Registrars;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

WebApplication.CreateBuilder(args)
    .RegisterServices()
    .Build()
    .SetupMiddleware()
    .Run();