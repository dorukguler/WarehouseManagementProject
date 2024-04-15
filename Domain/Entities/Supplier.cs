using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Supplier: Entity<Guid>
{
    public string Name { get; set; }
    public string Contact { get; set; }
    

    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<Purchase> Purchases { get; set; }


    public Supplier()
    {
        Products = new HashSet<Product>();
        Purchases = new HashSet<Purchase>();
    }
}