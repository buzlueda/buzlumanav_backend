using BuzluManav.Core.Application.Interfaces.Services;
using CorePackages.Core.Application.Pipelines.Transaction;
using MediatR;

namespace BuzluManav.Core.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest<DeletedCategoryResponse>, ITransactionalRequest
{
    public int Id { get; set; }
    public class DeleteCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<DeleteCategoryCommand, DeletedCategoryResponse>
    {
        public async Task<DeletedCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await categoryService.DeleteCategoryAsync(request.Id);
            return result;
        }
    }
}