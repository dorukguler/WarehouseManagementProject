using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TransactionTypeRepository: EfRepositoryBase<TransactionType,int,BaseDbContext>, ITransactionTypeRepository
{
    public TransactionTypeRepository(BaseDbContext context) : base(context)
    {
    }
}