using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Stock: Entity<Guid>
{
    
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public virtual Product Product { get; set; }

    public Stock()
    {
        
    }

    public Stock(Guid id, Guid productId, int quantity)
    {
        Id = id;
        ProductId = productId;
        Quantity = quantity;
    }
}