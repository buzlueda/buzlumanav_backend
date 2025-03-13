namespace BuzluManav.Core.Application.Features.Products.Commands.Update;

public record struct UpdatedProductResponse(int Id, string Name, string Description, decimal Price, int Stock, string ImageUrl, bool IsActive)
{
    public UpdatedProductResponse() : this(default, string.Empty, string.Empty, default, default, string.Empty, default)
    {
    }
}