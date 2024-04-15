using Application.Features.Suppliers.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SuppliersController: BaseController
{
    // [HttpPost]
    // public async Task<IActionResult> Add([FromBody] CreateSupplierCommand createSupplierCommand)
    // {
    //     CreatedSupplierResponse response = await Mediator.Send(createSupplierCommand);
    //     return Ok(response);
    // }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSupplierQuery getListSupplierQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSupplierListItemDto> response = await Mediator.Send(getListSupplierQuery);
        return Ok(response);
    }

}