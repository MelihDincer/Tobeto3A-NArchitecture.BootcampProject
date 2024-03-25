using Application.Features.BlackLists.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BlackLists;

public class BlackListManager : IBlackListService
{
    private readonly IBlackListRepository _blackListRepository;
    private readonly BlackListBusinessRules _blackListBusinessRules;

    public BlackListManager(IBlackListRepository blackListRepository, BlackListBusinessRules blackListBusinessRules)
    {
        _blackListRepository = blackListRepository;
        _blackListBusinessRules = blackListBusinessRules;
    }

    public async Task<BlackList?> GetAsync(
        Expression<Func<BlackList, bool>> predicate,
        Func<IQueryable<BlackList>, IIncludableQueryable<BlackList, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BlackList? blackList = await _blackListRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return blackList;
    }

    public async Task<IPaginate<BlackList>?> GetListAsync(
        Expression<Func<BlackList, bool>>? predicate = null,
        Func<IQueryable<BlackList>, IOrderedQueryable<BlackList>>? orderBy = null,
        Func<IQueryable<BlackList>, IIncludableQueryable<BlackList, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BlackList> blackListList = await _blackListRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return blackListList;
    }

    public async Task<BlackList> AddAsync(BlackList blackList)
    {
        BlackList addedBlackList = await _blackListRepository.AddAsync(blackList);

        return addedBlackList;
    }

    public async Task<BlackList> UpdateAsync(BlackList blackList)
    {
        BlackList updatedBlackList = await _blackListRepository.UpdateAsync(blackList);

        return updatedBlackList;
    }

    public async Task<BlackList> DeleteAsync(BlackList blackList, bool permanent = false)
    {
        BlackList deletedBlackList = await _blackListRepository.DeleteAsync(blackList);

        return deletedBlackList;
    }
}
