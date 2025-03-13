using Microsoft.AspNetCore.Http;

namespace BuzluManav.Core.Application.Features.Products.Models;

public record CreateProductModel(int CategoryId, string Name, string Description, decimal Price, int Stock, IFormFile ImageUrl, bool IsActive)
{
    public CreateProductModel() : this(default, string.Empty, string.Empty, default, default, null!, default)
    {
    }
}