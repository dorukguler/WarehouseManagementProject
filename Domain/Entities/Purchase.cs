using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Purchase : Entity<Guid>
{
    public Guid SupplierId { get; set; }
    public DateTime PurchaseDate { get; set; }
    
    public virtual Supplier Supplier { get; set; }
    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
}