namespace Application.Features.Stocks.Commands.Create;

public class CreatedStockResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}