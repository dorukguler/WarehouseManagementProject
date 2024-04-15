using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StockConfiguration: IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stocks").HasKey(stock => stock.Id );
        
        builder.Property(stock => stock.Id).HasColumnName("Id").IsRequired();
        builder.Property(stock => stock.Quantity).HasColumnName("Quantity").IsRequired();
        builder.Property(stock => stock.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(stock => stock.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(stock => stock.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(stock => stock.Product);
        builder.HasQueryFilter(stock => !stock.DeletedDate.HasValue);
    }
}