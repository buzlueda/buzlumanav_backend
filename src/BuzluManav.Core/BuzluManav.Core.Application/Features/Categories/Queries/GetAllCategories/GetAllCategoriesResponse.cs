namespace BuzluManav.Core.Application.Features.Categories.Queries.GetAllCategories;

public record struct GetAllCategoriesResponse(int Id, string Name, string Description, string ImageUrl, bool IsActive, string Slug)
{
    public GetAllCategoriesResponse() : this(0, string.Empty, string.Empty, string.Empty, false, string.Empty) { }
}