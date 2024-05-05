using Application.Features.Sales.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController: BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSaleCommand createSaleCommand)
    {
        CreatedSaleResponse response = await Mediator.Send(createSaleCommand);
        return Ok(response);
    }
    
    // [HttpGet]
    // public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    // {
    //     GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest };
    //     GetListResponse<GetListProductListItemDto> response = await Mediator.Send(getListProductQuery);
    //     return Ok(response);
    // }

}