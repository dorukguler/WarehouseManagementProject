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

    public async Task<Transaction> CreateSaleTransaction(Sale sale, SaleDetail saleDetail)
    {
        Transaction transaction = new()
        {
            ProductId = saleDetail.ProductId,
            CustomerId = sale.CustomerId,
            SupplierId = null,
            TransactionTypeId = 2,
            TransactionTime = DateTime.UtcNow,
            SaleId = sale.Id,
            Quantity = saleDetail.Quantity
        };
        return await Task.FromResult(transaction);
    }

    public async Task<Transaction> Add(Transaction transaction)
    {
        Transaction createdTransaction = await _transactionRepository.AddAsync(transaction);
        return createdTransaction;
    }
}