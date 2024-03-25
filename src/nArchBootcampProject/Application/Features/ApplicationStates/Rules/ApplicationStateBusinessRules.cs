using Application.Features.ApplicationStates.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ApplicationStates.Rules;

public class ApplicationStateBusinessRules : BaseBusinessRules
{
    private readonly IApplicationStateRepository _applicationStateRepository;
    private readonly ILocalizationService _localizationService;

    public ApplicationStateBusinessRules(IApplicationStateRepository applicationStateRepository, ILocalizationService localizationService)
    {
        _applicationStateRepository = applicationStateRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ApplicationStatesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ApplicationStateShouldExistWhenSelected(ApplicationState? applicationState)
    {
        if (applicationState == null)
            await throwBusinessException(ApplicationStatesBusinessMessages.ApplicationStateNotExists);
    }

    public async Task ApplicationStateIdShouldExistWhenSelected(short id, CancellationToken cancellationToken)
    {
        ApplicationState? applicationState = await _applicationStateRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicationStateShouldExistWhenSelected(applicationState);
    }
}