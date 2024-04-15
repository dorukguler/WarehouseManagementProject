using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(product => product.Id);
        
        builder.Property(product => product.Id).HasColumnName("Id").IsRequired();
        builder.Property(product => product.Name).HasColumnName("Name").IsRequired();
        builder.Property(product => product.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(product => product.SupplierId).HasColumnName("SupplierId").IsRequired();
        builder.Property(product => product.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(product => product.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(product => product.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(product => product.Supplier);
        builder.HasOne(product => product.Category);
        builder.HasQueryFilter(product => !product.DeletedDate.HasValue);

    }
}