

using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Customer: Entity<Guid>
{
    public string Name { get; set; }
    public string Contact { get; set; }
    
    
    
    public Customer()
    {
        
    }

    public Customer(Guid id,string name, string contact)
    {
        Id = id;
        Name = name;
        Contact = contact;
    }
}