using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPurchaseDetailRepository : IAsyncRepository<PurchaseDetail,Guid>, IRepository<PurchaseDetail,Guid>
{
    
}