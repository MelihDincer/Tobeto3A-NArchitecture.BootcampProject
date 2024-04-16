using Application.Features.BlackLists.Constants;
using Application.Features.BlackLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.BlackLists.Constants.BlackListsOperationClaims;

namespace Application.Features.BlackLists.Commands.Update;

public class UpdateBlackListCommand
    : IRequest<UpdatedBlackListResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }
    public Guid ApplicantId { get; set; }
    public string? Reason { get; set; }
    public DateTime Date { get; set; }

    public string[] Roles => [Admin, Write, BlackListsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlackLists"];

    public class UpdateBlackListCommandHandler : IRequestHandler<UpdateBlackListCommand, UpdatedBlackListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlackListRepository _blackListRepository;
        private readonly BlackListBusinessRules _blackListBusinessRules;

        public UpdateBlackListCommandHandler(
            IMapper mapper,
            IBlackListRepository blackListRepository,
            BlackListBusinessRules blackListBusinessRules
        )
        {
            _mapper = mapper;
            _blackListRepository = blackListRepository;
            _blackListBusinessRules = blackListBusinessRules;
        }

        public async Task<UpdatedBlackListResponse> Handle(UpdateBlackListCommand request, CancellationToken cancellationToken)
        {
            BlackList? blackList = await _blackListRepository.GetAsync(
                predicate: bl => bl.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _blackListBusinessRules.BlackListShouldExistWhenSelected(blackList);
            blackList = _mapper.Map(request, blackList);

            await _blackListRepository.UpdateAsync(blackList!);

            UpdatedBlackListResponse response = _mapper.Map<UpdatedBlackListResponse>(blackList);
            return response;
        }
    }
}
