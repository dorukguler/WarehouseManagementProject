using Domain.Entities;

namespace Application.Services.TransactionService;

public interface ITransactionService
{
    // public Task<Transaction> CreateTransaction(Order order);
    Task<Transaction> CreatePurchaseTransaction(Purchase purchase, PurchaseDetail purchaseDetail);
    Task<Transaction> Add(Transaction transaction);
}