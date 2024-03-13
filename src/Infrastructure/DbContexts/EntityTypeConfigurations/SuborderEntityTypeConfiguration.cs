using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Secure.Business.Infrastructure.DbContexts.EntityTypeConfigurations;

public class SuborderEntityTypeConfiguration : IEntityTypeConfiguration<Suborder>
{
    public void Configure(EntityTypeBuilder<Suborder> builder)
    {
        builder.ToTable("suborder");

        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.SuborderType)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.ShippingType)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.Status)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.Promotion)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.SuborderDiscount)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.Items)
            .HasColumnType("jsonb");
        
        builder.HasOne(d => d.Orders)
            .WithMany(p => p.Suborders)
            .HasForeignKey(d => d.OrderId);
    }
}