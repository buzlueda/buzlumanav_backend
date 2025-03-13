using BuzluManav.Core.Application.Features.Products.Models;
using BuzluManav.Core.Application.Interfaces.Services;
using CorePackages.Core.Application.Pipelines.Authorization;
using CorePackages.Core.Application.Pipelines.Transaction;
using MediatR;

namespace BuzluManav.Core.Application.Features.Products.Commands.Update;

public class UpdateProductCommand : IRequest<UpdatedProductResponse>, ITransactionalRequest, ISecuredRequest
{
    public string[] Roles => ["Admin"];
    public UpdateProductModel UpdateProductModel { get; set; } = new();

    public class UpdateProductCommandHandler(IProductService productService) : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
    {
        public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await productService.UpdateProductAsync(request.UpdateProductModel);
            return result;
        }
    }
}
