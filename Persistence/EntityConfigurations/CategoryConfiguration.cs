using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(category => category.Id);
        
        builder.Property(category => category.Id).HasColumnName("Id").IsRequired();
        builder.Property(category => category.Name).HasColumnName("Name").IsRequired();
        builder.Property(category => category.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(category => category.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(category => category.DeletedDate).HasColumnName("DeletedDate");
        
        builder.HasQueryFilter(category => !category.DeletedDate.HasValue);
        
        
    }
}