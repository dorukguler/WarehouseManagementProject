namespace Application.Features.Products.Queries;

public class GetListProductListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string SupplierName { get; set; }
    public string CategoryName { get; set; }
}