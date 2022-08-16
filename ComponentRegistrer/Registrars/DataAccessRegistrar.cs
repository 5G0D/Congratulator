using AppServices.Birthdays.Repositories;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Register.Registrars;

public static class DataAccessRegistrar
{
    private const string ConnectionStringsLocal = "ConnectionStringsLocal";
    private const string ConnectionStringsDocker = "ConnectionStringsDocker";

    public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment )
    {
        /*var connectionStringFieldName = environment.IsDevelopment()
            ? ConnectionStringsLocal
            : ConnectionStringsDocker;
        
        var connectionString = configuration.GetConnectionString(connectionStringFieldName);
        
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException(
                $"Не найдена строка подключения с именем '{connectionStringFieldName}'");
            
        services.AddDbContextPool<FamilyBudgetDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseLazyLoadingProxies();
        });*/

        services.AddScoped<DbContext>(sp => sp.GetRequiredService<CongratulatorDbContext>());
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
        services.AddScoped<IBirthdayRepository, BirthdayRepository>();
    }
}