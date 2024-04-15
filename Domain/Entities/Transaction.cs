using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Transaction :Entity<Guid>
{
    public Guid ProductId { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? SupplierId { get; set; }
    public int TransactionTypeId { get; set; }
    public DateTime TransactionTime { get; set; }
    public int Quantity { get; set; }
    public Guid PurchaseId { get; set; }
    

    public virtual Customer Customer { get; set; }
    public virtual Supplier Supplier { get; set; }
    public virtual Product Product { get; set; }
    // public virtual Order Purchase { get; set; }
    
    public virtual TransactionType TransactionType { get; set; }

    public Transaction()
    {
        
    }

    public Transaction(Guid id,  Guid productId, Guid? customerId,Guid? supplierId,int transactionTypeId,DateTime transactionTime,int quantity, Guid purchaseId) 
    {
        Id = id;
        ProductId = productId;
        CustomerId = customerId;
        SupplierId = supplierId;
        TransactionTypeId = transactionTypeId;
        TransactionTime = transactionTime;
        Quantity = quantity;
        PurchaseId = purchaseId;
    } 
}