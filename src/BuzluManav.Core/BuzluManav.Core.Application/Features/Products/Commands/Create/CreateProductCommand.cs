using BuzluManav.Core.Application.Features.Products.Models;
using BuzluManav.Core.Application.Interfaces.Services;
using CorePackages.Core.Application.Pipelines.Authorization;
using CorePackages.Core.Application.Pipelines.Transaction;
using MediatR;

namespace BuzluManav.Core.Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<CreatedProductResponse>, ITransactionalRequest, ISecuredRequest
{
    public string[] Roles => ["Admin"];
    public CreateProductModel CreateProductModel { get; set; } = new();

    public class CreateProductCommandHandler(IProductService productService) : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await productService.CreateProductAsync(request.CreateProductModel);
            return result;
        }
    }
}
