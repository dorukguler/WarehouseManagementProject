using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SaleDetailRepository: EfRepositoryBase<SaleDetail,Guid,BaseDbContext>, ISaleDetailRepository
{
    public SaleDetailRepository(BaseDbContext context) : base(context)
    {
    }
}