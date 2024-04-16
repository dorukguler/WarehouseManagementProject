using Application.Features.Purchases.Commands.Create;
using Application.Services.Repositories;
using Application.Services.StockService;
using Domain.Entities;

namespace Application.Services.PurchaseService;

public class PurchaseManager : IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;
    
    
    public PurchaseManager(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
        
    }
    
    
}