using Application.Features.Sales.Queries;

namespace Application.Features.Sales.Commands.Create;

public class CreatedSaleResponse
{
    public Guid CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public List<SaleDetailDto> SaleDetails { get; set; }
}