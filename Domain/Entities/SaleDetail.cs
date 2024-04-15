using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class SaleDetail: Entity<Guid>
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public int SalePrice { get; set; } 
    
    public virtual Sale Sale { get; set; }
    public virtual Product Product { get; set; }
}