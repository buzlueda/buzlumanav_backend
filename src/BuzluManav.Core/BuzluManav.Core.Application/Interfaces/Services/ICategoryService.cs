using BuzluManav.Core.Application.Features.Categories.Commands.Create;
using BuzluManav.Core.Application.Features.Categories.Commands.Delete;
using BuzluManav.Core.Application.Features.Categories.Models;
using BuzluManav.Core.Application.Features.Categories.Queries.GetAllCategories;
using CorePackages.Core.Application.Requests;
using CorePackages.Core.Application.Responses;

namespace BuzluManav.Core.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CreatedCategoryResponse> CreateCategoryAsync(CreateCategoryModel model);
        Task<DeletedCategoryResponse> DeleteCategoryAsync(int id);
        Task<GetListResponse<GetAllCategoriesResponse>> GetAllCategoriesAsync(PageRequest pageRequest);
    }
}