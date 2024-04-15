using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(customer =>  customer.Id);
        
        builder.Property(customer => customer.Id).HasColumnName("Id").IsRequired();
        builder.Property(customer => customer.Name).HasColumnName("Name").IsRequired();
        builder.Property(customer => customer.Contact).HasColumnName("Contact").IsRequired();
        
        builder.HasQueryFilter(customer => !customer.DeletedDate.HasValue);
    }
}