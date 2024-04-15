using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PurchaseDetailConfiguration : IEntityTypeConfiguration<PurchaseDetail>
{
    public void Configure(EntityTypeBuilder<PurchaseDetail> builder)
    {
        builder.ToTable("PurchaseDetails").HasKey(pdetail =>  pdetail.Id);
        
        builder.Property(pdetail => pdetail.Id).HasColumnName("Id").IsRequired();
        builder.Property(pdetail => pdetail.PurchaseId).HasColumnName("PurchaseId").IsRequired();
        builder.Property(pdetail => pdetail.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(pdetail => pdetail.Quantity).HasColumnName("Quantity").IsRequired();
        builder.Property(pdetail => pdetail.CostPrice).HasColumnName("CostPrice").IsRequired();
        builder.Property(pdetail => pdetail.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pdetail => pdetail.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pdetail => pdetail.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(pdetail => pdetail.Purchase);
        builder.HasQueryFilter(pdetail => !pdetail.DeletedDate.HasValue);

    }
}