using BuzluManav.Core.Domain.Entities;
using CorePackages.Infrastructure.Persistence.Repositories.Common;

namespace BuzluManav.Core.Application.Interfaces.Repositories;

public interface IDistrictRepository : IAsyncRepository<District, int>, IRepository<District, int>
{
}