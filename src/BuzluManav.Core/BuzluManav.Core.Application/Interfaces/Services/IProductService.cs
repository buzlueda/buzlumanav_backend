using BuzluManav.Core.Application.Features.Products.Commands.Create;
using BuzluManav.Core.Application.Features.Products.Commands.Update;
using BuzluManav.Core.Application.Features.Products.Models;

namespace BuzluManav.Core.Application.Interfaces.Services;

public interface IProductService
{
    Task<CreatedProductResponse> CreateProductAsync(CreateProductModel createProductModel);
    Task<UpdatedProductResponse> UpdateProductAsync(UpdateProductModel updateProductModel);
}