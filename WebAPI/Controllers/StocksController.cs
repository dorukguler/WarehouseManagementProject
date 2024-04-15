using Application.Features.Stocks.Commands.Create;
using Application.Features.Stocks.Queries.GetList;
using Application.Stocks.Queries;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StocksController: BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStockCommand createStockCommand)
    {
        CreatedStockResponse response = await Mediator.Send(createStockCommand);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStockQuery getListStockQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStockListItemDto> response = await Mediator.Send(getListStockQuery);
        return Ok(response);
    }

}