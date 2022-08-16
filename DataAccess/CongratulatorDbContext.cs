using DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class CongratulatorDbContext : DbContext
{
    public CongratulatorDbContext(DbContextOptions<CongratulatorDbContext> options)
        : base(options)
    {
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new BirthdayConfiguration());
    }
}