using Domain.Entities;

namespace Application.Services.PurchaseService;

public interface IPurchaseService
{
    Task<Stock> UpdateStockQuantityBasedOnPurchaseQuantity(Guid productId, int quantity);
}