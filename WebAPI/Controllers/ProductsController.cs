
using Application.Features.Products.Commands.Create;
using Application.Features.Products.Queries;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductsController: BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
    {
        CreatedProductResponse response = await Mediator.Send(createProductCommand);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductListItemDto> response = await Mediator.Send(getListProductQuery);
        return Ok(response);
    }

}