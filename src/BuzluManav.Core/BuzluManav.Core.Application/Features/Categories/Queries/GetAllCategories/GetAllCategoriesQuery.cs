using BuzluManav.Core.Application.Interfaces.Services;
using CorePackages.Core.Application.Requests;
using CorePackages.Core.Application.Responses;
using MediatR;

namespace BuzluManav.Core.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<GetListResponse<GetAllCategoriesResponse>>
{
    public PageRequest PageRequest { get; set; } = new();
    public class GetAllCategoriesQueryHandler(ICategoryService categoryService) : IRequestHandler<GetAllCategoriesQuery, GetListResponse<GetAllCategoriesResponse>>
    {
        public async Task<GetListResponse<GetAllCategoriesResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await categoryService.GetAllCategoriesAsync(request.PageRequest);
            return result;
        }
    }
}