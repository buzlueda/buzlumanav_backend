using BuzluManav.Core.Application.Features.Categories.Models;
using BuzluManav.Core.Application.Interfaces.Services;
using CorePackages.Core.Application.Pipelines.Transaction;
using MediatR;

namespace BuzluManav.Core.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ITransactionalRequest
{
    public CreateCategoryModel Model { get; set; }
    public class CreateCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
    {
        public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await categoryService.CreateCategoryAsync(request.Model);
            return result;
        }
    }
}