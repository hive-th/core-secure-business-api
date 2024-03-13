using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Secure.Business.Infrastructure.DbContexts.EntityTypeConfigurations;

public class OrderRequestEntityTypeConfiguration : IEntityTypeConfiguration<OrderRequest>
{
    public void Configure(EntityTypeBuilder<OrderRequest> builder)
    {
        builder.ToTable("order_request");

        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Promotion)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.Buyer)
            .HasColumnType("jsonb");
    }
}