namespace Application.Features.Sales.Queries;

public class SaleDetailDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public int SalePrice { get; set; }
}