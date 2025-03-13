using Microsoft.AspNetCore.Http;

namespace BuzluManav.Core.Application.Features.Products.Models;

public record UpdateProductModel(int Id, int CategoryId, string Name, string Description, decimal Price, int Stock, IFormFile ImageUrl, bool IsActive)
{
    public UpdateProductModel() : this(default, default, string.Empty, string.Empty, default, default, null!, default)
    {
    }
}