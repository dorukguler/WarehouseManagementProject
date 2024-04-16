using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions").HasKey(transaction => transaction.Id);
        
        builder.Property(transaction => transaction.Id).HasColumnName("Id").IsRequired();
        builder.Property(transaction => transaction.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(transaction => transaction.TransactionTypeId).HasColumnName("TransactionTypeId").IsRequired();
        builder.Property(transaction => transaction.TransactionTime).HasColumnName("TransactionTime").IsRequired();
        builder.Property(transaction => transaction.CustomerId).HasColumnName("CustomerId");
        builder.Property(transaction => transaction.SupplierId).HasColumnName("SupplierId");
        builder.Property(transaction => transaction.Quantity).HasColumnName("Quantity").IsRequired();
        builder.Property(transaction => transaction.PurchaseId).HasColumnName("PurchaseId");
        builder.Property(transaction => transaction.SaleId).HasColumnName("SaleId");
        builder.Property(transaction => transaction.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(transaction => transaction.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(transaction => transaction.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(transaction => transaction.Product);
        builder.HasOne(transaction => transaction.Customer);
        builder.HasOne(transaction => transaction.TransactionType);
        builder.HasQueryFilter(transaction => !transaction.DeletedDate.HasValue);
    }
}