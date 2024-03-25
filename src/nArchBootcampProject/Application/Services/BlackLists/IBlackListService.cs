using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BlackLists;

public interface IBlackListService
{
    Task<BlackList?> GetAsync(
        Expression<Func<BlackList, bool>> predicate,
        Func<IQueryable<BlackList>, IIncludableQueryable<BlackList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BlackList>?> GetListAsync(
        Expression<Func<BlackList, bool>>? predicate = null,
        Func<IQueryable<BlackList>, IOrderedQueryable<BlackList>>? orderBy = null,
        Func<IQueryable<BlackList>, IIncludableQueryable<BlackList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BlackList> AddAsync(BlackList blackList);
    Task<BlackList> UpdateAsync(BlackList blackList);
    Task<BlackList> DeleteAsync(BlackList blackList, bool permanent = false);
}
