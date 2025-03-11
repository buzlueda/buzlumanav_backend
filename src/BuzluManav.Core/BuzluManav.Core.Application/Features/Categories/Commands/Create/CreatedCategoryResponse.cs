namespace BuzluManav.Core.Application.Features.Categories.Commands.Create;

public record struct CreatedCategoryResponse(int Id, string Name, string Description, string ImageUrl, bool IsActive, string Slug)
{
    public CreatedCategoryResponse() : this(0, string.Empty, string.Empty, string.Empty, false, string.Empty) { }
}