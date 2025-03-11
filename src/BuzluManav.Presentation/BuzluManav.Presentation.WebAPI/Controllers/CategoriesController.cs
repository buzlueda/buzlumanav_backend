using BuzluManav.Core.Application.Features.Categories.Commands.Create;
using BuzluManav.Core.Application.Features.Categories.Commands.Delete;
using BuzluManav.Core.Application.Features.Categories.Models;
using BuzluManav.Core.Application.Features.Categories.Queries.GetAllCategories;
using CorePackages.Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BuzluManav.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync([FromForm] CreateCategoryModel createCategoryModel)
    {
        CreateCategoryCommand command = new() { Model = createCategoryModel };
        var result = await Mediator.Send(command);
        return HandleErrors(() => result);
    }

    // [HttpPut]
    // public async Task<IActionResult> UpdateCategoryAsync(int id, [FromForm] UpdateCategoryModel updateCategoryModel)
    // {
    //     UpdateCategoryCommand command = new() { Id = id, Model = updateCategoryModel };
    //     var result = await Mediator.Send(command);
    //     return HandleErrors(() => result);
    // }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        DeleteCategoryCommand command = new() { Id = id };
        var result = await Mediator.Send(command);
        return HandleErrors(() => result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategoriesAsync([FromQuery] PageRequest pageRequest)
    {
        GetAllCategoriesQuery query = new() { PageRequest = pageRequest };
        var result = await Mediator.Send(query);
        return HandleErrors(() => result);
    }

    // [HttpGet("{slug}")]
    // public async Task<IActionResult> GetCategoryBySlugAsync(string slug)
    // {
    //     GetCategoryBySlugQuery query = new() { Slug = slug };
    //     var result = await Mediator.Send(query);
    //     return HandleErrors(() => result);
    // }
}