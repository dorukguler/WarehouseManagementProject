using Application.Features.Products.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.Products.Rules;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductRepository _productRepository;

    public ProductBusinessRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ProductNameCanNotBeDuplicatedWhenInserted(string name)
    {
        Product? result = await _productRepository.GetAsync(x => x.Name.ToLower() == name.ToLower());
        if (result != null)
            throw new BusinessException(ProductMessages.ProductNameExists);
    }

    public async Task ProductNameCanNotBeDuplicatedWhenUpdated(Product product)
    {
        Product? result = await _productRepository.GetAsync(x => x.Id != product.Id && x.Name.ToLower() == product.Name.ToLower());
        if (result != null)
            throw new BusinessException(ProductMessages.ProductNameExists);
    }
    
}