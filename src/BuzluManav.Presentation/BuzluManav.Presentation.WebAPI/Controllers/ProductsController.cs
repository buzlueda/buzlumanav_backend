using BuzluManav.Core.Application.Features.Products.Commands.Create;
using BuzluManav.Core.Application.Features.Products.Commands.Update;
using BuzluManav.Core.Application.Features.Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuzluManav.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductModel createProductModel)
    {
        CreateProductCommand command = new() { CreateProductModel = createProductModel };
        var result = await Mediator.Send(command);
        return HandleErrors(() => result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync([FromForm] UpdateProductModel updateProductModel)
    {
        UpdateProductCommand command = new() { UpdateProductModel = updateProductModel };
        var result = await Mediator.Send(command);
        return HandleErrors(() => result);
    }

//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteProductAsync(int id)
//     {
//         DeleteProductCommand command = new() { Id = id };
//         var result = await Mediator.Send(command);
//         return HandleErrors(() => result);
//     }

//     [HttpGet]
//     public async Task<IActionResult> GetAllProductsAsync([FromQuery] PageRequest pageRequest)
//     {
//         GetAllProductsQuery query = new() { PageRequest = pageRequest };
//         var result = await Mediator.Send(query);
//         return HandleErrors(() => result);
//     }
}