using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPurchaseRepository: IAsyncRepository<Purchase,Guid>, IRepository<Purchase,Guid>
{
    
}