using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers").HasKey(supplier =>  supplier.Id);
        
        builder.Property(supplier => supplier.Id).HasColumnName("Id").IsRequired();
        builder.Property(supplier => supplier.Name).HasColumnName("Name").IsRequired();
        builder.Property(supplier => supplier.Contact).HasColumnName("Contact").IsRequired();
        
        builder.HasQueryFilter(supplier => !supplier.DeletedDate.HasValue);
    }
}