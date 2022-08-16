using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class BirthdayConfiguration : IEntityTypeConfiguration<BirthdayEntity>
{
    public void Configure(EntityTypeBuilder<BirthdayEntity> builder)
    {
        
    }
}