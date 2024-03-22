using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Secure.Business.Infrastructure.DbContexts.EntityTypeConfigurations;

public class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("cart");

        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.CartType)
            .HasConversion<string>();
        
        builder.Property(m => m.Dealers)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.Promotions)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.Summary)
            .HasColumnType("jsonb");
    }
}