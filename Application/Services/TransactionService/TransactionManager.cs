using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Services.TransactionService;

public class TransactionManager : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionManager(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    
    // public Task<Transaction> CreateTransaction(Order order)
    // {
    //     Transaction transaction = new()
    //     {
    //         ProductId = order.ProductId,
    //         CustomerId = order.CustomerId,
    //         TransactionTypeId = order.OrderTypeId,
    //         TransactionTime = DateTime.UtcNow,
    //         OrderId = order.Id,
    //         Quantity = order.Quantity
    //     };
    //     return Task.FromResult(transaction);
    // }

    public async Task<Transaction> CreatePurchaseTransaction(Purchase purchase,PurchaseDetail purchaseDetail)
    {
        Transaction transaction = new()
        {
            ProductId = purchaseDetail.ProductId,
            CustomerId = null,
            SupplierId = purchase.SupplierId,
            TransactionTypeId = 1,
            TransactionTime = DateTime.UtcNow,
            PurchaseId = purchase.Id,
            Quantity = purchaseDetail.Quantity
        };
        return await Task.FromResult(transaction);
    }

    public async Task<Transaction> Add(Transaction transaction)
    {
        Transaction createdTransaction = await _transactionRepository.AddAsync(transaction);
        return createdTransaction;
    }
}