using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITransactionTypeRepository: IAsyncRepository<TransactionType,int>, IRepository<TransactionType,int>
{
   
}