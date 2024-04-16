using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISaleDetailRepository: IAsyncRepository<SaleDetail,Guid>, IRepository<SaleDetail,Guid>
{
    
}