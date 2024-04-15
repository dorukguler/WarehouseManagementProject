namespace Application.Features.Stocks.Commands.Update;

public class UpdatedStockResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; } 
}