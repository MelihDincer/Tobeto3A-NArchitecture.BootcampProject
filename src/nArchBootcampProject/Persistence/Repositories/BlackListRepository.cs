using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BlackListRepository : EfRepositoryBase<BlackList, int, BaseDbContext>, IBlackListRepository
{
    public BlackListRepository(BaseDbContext context) : base(context)
    {
    }
}