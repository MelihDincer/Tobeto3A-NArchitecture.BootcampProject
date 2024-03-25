using Application.Features.ApplicationStates.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ApplicationStates;

public class ApplicationStateManager : IApplicationStateService
{
    private readonly IApplicationStateRepository _applicationStateRepository;
    private readonly ApplicationStateBusinessRules _applicationStateBusinessRules;

    public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, ApplicationStateBusinessRules applicationStateBusinessRules)
    {
        _applicationStateRepository = applicationStateRepository;
        _applicationStateBusinessRules = applicationStateBusinessRules;
    }

    public async Task<ApplicationState?> GetAsync(
        Expression<Func<ApplicationState, bool>> predicate,
        Func<IQueryable<ApplicationState>, IIncludableQueryable<ApplicationState, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ApplicationState? applicationState = await _applicationStateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return applicationState;
    }

    public async Task<IPaginate<ApplicationState>?> GetListAsync(
        Expression<Func<ApplicationState, bool>>? predicate = null,
        Func<IQueryable<ApplicationState>, IOrderedQueryable<ApplicationState>>? orderBy = null,
        Func<IQueryable<ApplicationState>, IIncludableQueryable<ApplicationState, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ApplicationState> applicationStateList = await _applicationStateRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationStateList;
    }

    public async Task<ApplicationState> AddAsync(ApplicationState applicationState)
    {
        ApplicationState addedApplicationState = await _applicationStateRepository.AddAsync(applicationState);

        return addedApplicationState;
    }

    public async Task<ApplicationState> UpdateAsync(ApplicationState applicationState)
    {
        ApplicationState updatedApplicationState = await _applicationStateRepository.UpdateAsync(applicationState);

        return updatedApplicationState;
    }

    public async Task<ApplicationState> DeleteAsync(ApplicationState applicationState, bool permanent = false)
    {
        ApplicationState deletedApplicationState = await _applicationStateRepository.DeleteAsync(applicationState);

        return deletedApplicationState;
    }
}
