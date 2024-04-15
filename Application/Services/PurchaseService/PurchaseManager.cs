using Application.Features.Purchases.Commands.Create;
using Application.Services.Repositories;
using Application.Services.StockService;
using Domain.Entities;

namespace Application.Services.PurchaseService;

public class PurchaseManager : IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IStockService _stockService;
    
    public PurchaseManager(IPurchaseRepository purchaseRepository,IStockService stockService)
    {
        _purchaseRepository = purchaseRepository;
        _stockService = stockService;
    }
    
    public async Task<Stock> UpdateStockQuantityBasedOnPurchaseQuantity(Guid productId, int quantity)
    {
        Stock stock = await _stockService.GetStockByProductId(productId);



        return null; //await _purchaseRepository.UpdateAsync(stock);
    }
}