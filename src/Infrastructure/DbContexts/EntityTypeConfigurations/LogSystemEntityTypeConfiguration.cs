using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Secure.Business.Infrastructure.DbContexts.EntityTypeConfigurations;

public class LogSystemEntityTypeConfiguration : IEntityTypeConfiguration<LogSystem>
{
    public void Configure(EntityTypeBuilder<LogSystem> builder)
    {
        builder.ToTable("log_system");
        
        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Type)
            .HasConversion<string>();
        
        builder.Property(m => m.ObjectType)
            .HasConversion<string>();
        
        builder.Property(m => m.ObjectValue)
            .HasColumnType("jsonb");
    }
}