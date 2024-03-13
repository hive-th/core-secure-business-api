using Core.Secure.Business.Domain.AggregatesModel.EntityAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Secure.Business.Infrastructure.DbContexts.EntityTypeConfigurations;

public class OrderDocumentEntityTypeConfiguration : IEntityTypeConfiguration<OrderDocument>
{
    public void Configure(EntityTypeBuilder<OrderDocument> builder)
    {
        builder.ToTable("order_document");

        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.DocumentType)
            .HasColumnType("jsonb");
        
        builder.Property(m => m.RefDocumentType)
            .HasColumnType("jsonb");
        
        builder.HasOne(d => d.Orders)
            .WithMany(p => p.OrderDocuments)
            .HasForeignKey(d => d.OrderId);
        
        builder.HasOne(d => d.Suborders)
            .WithMany(p => p.OrderDocuments)
            .HasForeignKey(d => d.SuborderId);
    }
}