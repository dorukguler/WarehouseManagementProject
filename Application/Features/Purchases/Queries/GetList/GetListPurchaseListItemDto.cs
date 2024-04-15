namespace Application.Features.Purchases.Queries.GetListPurchaseListItemDto;

public class GetListPurchaseListItemDto
{
    public Guid SupplierId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}