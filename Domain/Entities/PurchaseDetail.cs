using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class PurchaseDetail: Entity<Guid>
{
    public Guid PurchaseId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public int CostPrice { get; set; } 
    
    public virtual Purchase Purchase { get; set; }
    public virtual Product Product { get; set; }
    
}