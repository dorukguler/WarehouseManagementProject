using Domain.Entities;

namespace Application.Services.StockService;

public interface IStockService
{
    Task<Stock> GetStockByProductId(Guid productId);
    Task<Stock> UpdateStockQuantityByProductId(Guid productId, int quantity);
    Task<Stock> UpdateStockQuantityBasedOnPurchaseQuantity(Guid productId, int quantity);
   
}