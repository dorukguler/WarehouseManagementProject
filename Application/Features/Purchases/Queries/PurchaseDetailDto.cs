namespace Application.Features.Purchases.Queries;

public class PurchaseDetailDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public int CostPrice { get; set; }
}