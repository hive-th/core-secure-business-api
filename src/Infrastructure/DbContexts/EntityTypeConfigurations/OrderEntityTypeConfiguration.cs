using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Secure.Business.Infrastructure.DbContexts.EntityTypeConfigurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order");

        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Status)
            .HasConversion<string>();
        
        builder.Property(m => m.ShippingLocation)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.TaxLocation)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.Payment)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.PaymentCharge)
            .HasColumnType("jsonb");
        
        builder.HasOne(d => d.OrderRequests)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.OrderRequestId);
    }
}