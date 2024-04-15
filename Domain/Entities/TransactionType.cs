using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class TransactionType: Entity<int>
{
    public string TypeName { get; set; }
    
    
    
   
    
    public TransactionType()
    {
        
    }
    
    public TransactionType(int id)
    {
        Id = id;
        TypeName = TypeName;
    }
}