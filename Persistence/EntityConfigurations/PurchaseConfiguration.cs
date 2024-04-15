using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Purchases").HasKey(purchase =>  purchase.Id);
        
        builder.Property(purchase => purchase.Id).HasColumnName("Id").IsRequired();
        builder.Property(purchase => purchase.SupplierId).HasColumnName("SupplierId").IsRequired();
        builder.Property(purchase => purchase.PurchaseDate).HasColumnName("PurchaseDate").IsRequired();
        builder.Property(purchase => purchase.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(purchase => purchase.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(purchase => purchase.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(purchase => purchase.Supplier);
        builder.HasQueryFilter(purchase => !purchase.DeletedDate.HasValue);

    }
}