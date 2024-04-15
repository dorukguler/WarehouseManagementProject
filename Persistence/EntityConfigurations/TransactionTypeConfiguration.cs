using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
{
    public void Configure(EntityTypeBuilder<TransactionType> builder)
    {
        builder.ToTable("TransactionTypes").HasKey(type => type.Id);
        
        builder.Property(type => type.Id).HasColumnName("Id").IsRequired();
        builder.Property(type => type.TypeName).HasColumnName("TypeName").IsRequired();
    }
}

