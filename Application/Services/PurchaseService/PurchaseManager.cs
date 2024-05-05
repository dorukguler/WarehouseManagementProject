using Application.Services.Repositories;

namespace Application.Services.PurchaseService;

public class PurchaseManager : IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;
    
    
    public PurchaseManager(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
        
    }
    
    
}