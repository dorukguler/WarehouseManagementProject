using Application.Features.Purchases.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseController: BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePurchaseCommand createPurchaseCommand)
    {
        CreatedPurchaseResponse response = await Mediator.Send(createPurchaseCommand);
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