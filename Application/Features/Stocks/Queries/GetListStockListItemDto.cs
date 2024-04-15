namespace Application.Stocks.Queries;

public class GetListStockListItemDto
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
   
    public int Quantity { get; set; }
}