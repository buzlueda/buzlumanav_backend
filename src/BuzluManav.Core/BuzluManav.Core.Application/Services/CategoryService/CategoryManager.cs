using AutoMapper;
using BuzluManav.Core.Application.Features.Categories.Commands.Create;
using BuzluManav.Core.Application.Features.Categories.Commands.Delete;
using BuzluManav.Core.Application.Features.Categories.Models;
using BuzluManav.Core.Application.Features.Categories.Queries.GetAllCategories;
using BuzluManav.Core.Application.Interfaces.Repositories.Common;
using BuzluManav.Core.Application.Interfaces.Services;
using BuzluManav.Core.Application.Services.CategoryService.Rules;
using BuzluManav.Core.Domain.Entities;
using BuzluManav.Infrastructure.Infrastructure.FileService;
using CorePackages.Core.Application.Requests;
using CorePackages.Core.Application.Responses;

namespace BuzluManav.Core.Application.Services.CategoryService;

public class CategoryManager(CategoryBusinessRules categoryBusinessRules, IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService) : ICategoryService
{
    public async Task<CreatedCategoryResponse> CreateCategoryAsync(CreateCategoryModel model)
    {
        var category = mapper.Map<Category>(model);
        await categoryBusinessRules.CheckIfCategoryAlreadyExistsAsync(model.Name);
        category.Slug = category.GenerateSlug();

        if (model.ImageUrl is not null)
        {
            category.ImageUrl = await fileService.UploadFileAsync(model.ImageUrl);
        }

        var createdCategory = await unitOfWork.CategoryRepository.AddAsync(category);
        return mapper.Map<CreatedCategoryResponse>(createdCategory);
    }

    public async Task<DeletedCategoryResponse> DeleteCategoryAsync(int id)
    {
        var category = await categoryBusinessRules.CheckIfCategoryExists(id);
        await unitOfWork.CategoryRepository.DeleteAsync(category);
        return mapper.Map<DeletedCategoryResponse>(category);
    }

    public async Task<GetListResponse<GetAllCategoriesResponse>> GetAllCategoriesAsync(PageRequest pageRequest)
    {
        var categories = await unitOfWork.CategoryRepository.GetListAsync(
            size: pageRequest.PageSize,
            index : pageRequest.PageIndex
        );
        return mapper.Map<GetListResponse<GetAllCategoriesResponse>>(categories);
    }
}