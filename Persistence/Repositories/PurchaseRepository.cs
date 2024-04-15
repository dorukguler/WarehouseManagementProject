using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;


public class PurchaseRepository: EfRepositoryBase<Purchase,Guid,BaseDbContext>, IPurchaseRepository
{
    public PurchaseRepository(BaseDbContext context) : base(context)
    {
    }
}