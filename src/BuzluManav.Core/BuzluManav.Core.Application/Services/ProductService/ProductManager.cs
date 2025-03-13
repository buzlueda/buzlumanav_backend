using BuzluManav.Core.Application.Features.Products.Commands.Create;
using BuzluManav.Core.Application.Features.Products.Models;
using BuzluManav.Core.Application.Interfaces.Services;

namespace BuzluManav.Core.Application.Services.ProductService;

public class ProductManager : IProductService
{
    public Task<CreatedProductResponse> CreateProductAsync(CreateProductModel createProductModel)
    {
        throw new NotImplementedException();
    }
}
