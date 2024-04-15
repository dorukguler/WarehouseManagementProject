using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;


public class Product: Entity<Guid>
{
    public string Name { get; set; }
    public Guid SupplierId { get; set; }
    public Guid CategoryId { get; set; }

    public virtual Supplier? Supplier { get; set; }
    public virtual Category? Category { get; set; }

    public Product()
    {
        
    }

    public Product(Guid id, string name, Guid supplierId, Guid categoryId) 
    {
        Id = id;
        Name = name;
        SupplierId = supplierId;
        CategoryId = categoryId;
    } 
}