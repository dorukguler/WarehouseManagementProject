using Application.Features.Stocks.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.Stocks.Rules;

public class StockBusinessRules: BaseBusinessRules
{
    private readonly IStockRepository _stockRepository;
    // private readonly IProduct _productRepository;

    public StockBusinessRules(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }
    
    public async Task StockProductMustExistsWhenStockInserted(Guid productId)
    {
        Stock? result = await _stockRepository.GetAsync(x => x.ProductId == productId);
        if (result == null)
            throw new BusinessException(StockMessages.ProductNotExists);
    }
    
    public async Task StockProductCanNotBeDuplicatedWhenInserted(Guid productId)
    {
        Stock? result = await _stockRepository.GetAsync(x => x.ProductId == productId);
        if (result != null)
            throw new BusinessException(StockMessages.StockProductExists);
    }

    public async Task StockProductCanNotBeDuplicatedWhenUpdated(Stock stock)
    {
        Stock? result = await _stockRepository.GetAsync(x => x.ProductId != stock.ProductId );
        if (result != null)
            throw new BusinessException(StockMessages.StockProductExists);
    }

}