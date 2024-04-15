using Application.Features.Purchases.Queries;

namespace Application.Features.Purchases.Commands.Create;

public class CreatedPurchaseResponse
{
    public Guid SupplierId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public List<PurchaseDetailDto> PurchaseDetails { get; set; }
   
}