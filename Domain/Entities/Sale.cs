using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Sale : Entity<Guid>
{
    public Guid CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    
    public virtual Customer Customer { get; set; }
    public virtual ICollection<SaleDetail> SaleDetails { get; set; }
}