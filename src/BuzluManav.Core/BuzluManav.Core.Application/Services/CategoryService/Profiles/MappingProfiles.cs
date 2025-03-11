using AutoMapper;
using BuzluManav.Core.Application.Features.Categories.Commands.Create;
using BuzluManav.Core.Application.Features.Categories.Commands.Delete;
using BuzluManav.Core.Application.Features.Categories.Models;
using BuzluManav.Core.Application.Features.Categories.Queries.GetAllCategories;
using BuzluManav.Core.Domain.Entities;
using CorePackages.Core.Application.Responses;
using CorePackages.Infrastructure.Persistence.Paging;

namespace BuzluManav.Core.Application.Services.CategoryService.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CreateCategoryModel>().ReverseMap();
        CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
        
        CreateMap<Category, DeletedCategoryResponse>().ReverseMap();

        CreateMap<Category, GetAllCategoriesResponse>().ReverseMap();
        CreateMap<IPaginate<Category>, GetListResponse<GetAllCategoriesResponse>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
    }
}