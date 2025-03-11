using BuzluManav.Core.Application.Interfaces.Repositories.Common;
using BuzluManav.Core.Application.Services.CategoryService.Constants;
using BuzluManav.Core.Domain.Entities;
using CorePackages.Core.Application.Rules;
using CorePackages.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.Types;

namespace BuzluManav.Core.Application.Services.CategoryService.Rules;

public class CategoryBusinessRules(IUnitOfWork unitOfWork) : BaseBusinessRules
{
    internal async Task CheckIfCategoryAlreadyExistsAsync(string name)
    {
        var category = await unitOfWork.CategoryRepository.GetAsync(
            predicate: x => x.Name == name);
        
        if (category != null)
        {
            throw new BusinessException(CategoryConstants.CategoryAlreadyExists);
        }
    }

    internal async Task<Category> CheckIfCategoryExists(int id)
    {
        var category = await unitOfWork.CategoryRepository.GetAsync(
            predicate: x => x.Id == id);
        
        if (category is null)
        {
            throw new BusinessException(CategoryConstants.CategoryNotFound);
        }
        return category;
    }
}