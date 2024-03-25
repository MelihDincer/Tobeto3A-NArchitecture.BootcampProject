using Application.Features.BlackLists.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BlackLists.Rules;

public class BlackListBusinessRules : BaseBusinessRules
{
    private readonly IBlackListRepository _blackListRepository;
    private readonly ILocalizationService _localizationService;

    public BlackListBusinessRules(IBlackListRepository blackListRepository, ILocalizationService localizationService)
    {
        _blackListRepository = blackListRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BlackListsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BlackListShouldExistWhenSelected(BlackList? blackList)
    {
        if (blackList == null)
            await throwBusinessException(BlackListsBusinessMessages.BlackListNotExists);
    }

    public async Task BlackListIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        BlackList? blackList = await _blackListRepository.GetAsync(
            predicate: bl => bl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BlackListShouldExistWhenSelected(blackList);
    }
}