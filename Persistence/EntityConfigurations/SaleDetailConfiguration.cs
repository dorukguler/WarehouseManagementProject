using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.ToTable("SaleDetails").HasKey(saleDetail =>  saleDetail.Id);
        
        builder.Property(saleDetail => saleDetail.Id).HasColumnName("Id").IsRequired();
        builder.Property(saleDetail => saleDetail.SaleId).HasColumnName("SaleId").IsRequired();
        builder.Property(saleDetail => saleDetail.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(saleDetail => saleDetail.SalePrice).HasColumnName("SalePrice").IsRequired();
        builder.Property(saleDetail => saleDetail.Quantity).HasColumnName("Quantity").IsRequired();
        builder.Property(saleDetail => saleDetail.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(saleDetail => saleDetail.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(saleDetail => saleDetail.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(saleDetail => saleDetail.Sale);
        builder.HasQueryFilter(saleDetail => !saleDetail.DeletedDate.HasValue);
    }
}