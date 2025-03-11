using Microsoft.AspNetCore.Http;

namespace BuzluManav.Core.Application.Features.Categories.Models;

public record CreateCategoryModel(string Name, string Description, IFormFile? ImageUrl, bool IsActive)
{
    public CreateCategoryModel() : this(string.Empty, string.Empty, null, false) { }
}