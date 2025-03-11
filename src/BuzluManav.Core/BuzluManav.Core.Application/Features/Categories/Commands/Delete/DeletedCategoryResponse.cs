namespace BuzluManav.Core.Application.Features.Categories.Commands.Delete;

public record struct DeletedCategoryResponse(int Id, string Name)
{
    public DeletedCategoryResponse() : this(0, string.Empty) { }
}