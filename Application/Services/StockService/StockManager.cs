using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Services.StockService;

public class StockManager : IStockService
{
    private readonly IStockRepository _stockRepository;
    

    public StockManager(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async Task<Stock> GetStockByProductId(Guid productId)
    {
        Stock stock = await _stockRepository.GetAsync(
            predicate: c=>c.ProductId == productId
        );
        return stock;
    }

    public async Task<Stock> UpdateStockQuantityByProductId(Guid productId, int quantity)
    {
        Stock stockToUpdateQuantity = await _stockRepository.GetAsync(
            predicate:  c=>c.ProductId == productId
        );
        stockToUpdateQuantity.Quantity += quantity;
        stockToUpdateQuantity.UpdatedDate = DateTime.UtcNow;

        await _stockRepository.UpdateAsync(stockToUpdateQuantity);
        
        return stockToUpdateQuantity;
    }

    public async Task<Stock> UpdateStockQuantityBasedOnPurchaseQuantity(Guid productId, int quantity)
    {
        Stock stockToUpdate = await _stockRepository.GetAsync(
            predicate:  c=>c.ProductId == productId
        );

        stockToUpdate.Quantity += quantity;
        stockToUpdate.UpdatedDate = DateTime.UtcNow;

        await _stockRepository.UpdateAsync(stockToUpdate);

        return stockToUpdate;
        
    }

    public async Task<Stock> UpdateStockQuantityBasedOnSaleQuantity(Guid productId, int quantity)
    {
        Stock stockToUpdate = await _stockRepository.GetAsync(
            predicate:  c=>c.ProductId == productId
        );

        stockToUpdate.Quantity -= quantity;
        stockToUpdate.UpdatedDate = DateTime.UtcNow;

        await _stockRepository.UpdateAsync(stockToUpdate);

        return stockToUpdate;
    }
}