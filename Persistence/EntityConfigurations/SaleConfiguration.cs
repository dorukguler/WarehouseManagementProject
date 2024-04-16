using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales").HasKey(sale =>  sale.Id);
        
        builder.Property(sale => sale.Id).HasColumnName("Id").IsRequired();
        builder.Property(sale => sale.CustomerId).HasColumnName("CustomerId").IsRequired();
        builder.Property(sale => sale.SaleDate).HasColumnName("SaleDate").IsRequired();
        builder.Property(sale => sale.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sale => sale.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sale => sale.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(sale => sale.Customer);
        builder.HasQueryFilter(sale => !sale.DeletedDate.HasValue);
    }
}