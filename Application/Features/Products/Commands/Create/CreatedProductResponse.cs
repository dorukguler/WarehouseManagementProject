namespace Application.Features.Products.Commands.Create;

public class CreatedProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SupplierId { get; set; }
}