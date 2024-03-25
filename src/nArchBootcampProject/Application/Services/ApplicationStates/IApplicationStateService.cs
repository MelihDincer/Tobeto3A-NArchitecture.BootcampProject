using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ApplicationStates;

public interface IApplicationStateService
{
    Task<ApplicationState?> GetAsync(
        Expression<Func<ApplicationState, bool>> predicate,
        Func<IQueryable<ApplicationState>, IIncludableQueryable<ApplicationState, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ApplicationState>?> GetListAsync(
        Expression<Func<ApplicationState, bool>>? predicate = null,
        Func<IQueryable<ApplicationState>, IOrderedQueryable<ApplicationState>>? orderBy = null,
        Func<IQueryable<ApplicationState>, IIncludableQueryable<ApplicationState, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ApplicationState> AddAsync(ApplicationState applicationState);
    Task<ApplicationState> UpdateAsync(ApplicationState applicationState);
    Task<ApplicationState> DeleteAsync(ApplicationState applicationState, bool permanent = false);
}
