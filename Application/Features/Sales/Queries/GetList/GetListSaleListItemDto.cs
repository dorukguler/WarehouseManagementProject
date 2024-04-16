namespace Application.Features.Sales.Queries.GetList;

public class GetListSaleListItemDto
{
    public Guid CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}