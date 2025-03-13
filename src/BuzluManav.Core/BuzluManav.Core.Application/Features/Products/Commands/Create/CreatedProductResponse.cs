namespace BuzluManav.Core.Application.Features.Products.Commands.Create;

public record struct CreatedProductResponse(int Id, string Name, string Description, decimal Price, int Stock, string ImageUrl, bool IsActive)
{
    public CreatedProductResponse() : this(default, string.Empty, string.Empty, default, default, string.Empty, default)
    {
    }
}