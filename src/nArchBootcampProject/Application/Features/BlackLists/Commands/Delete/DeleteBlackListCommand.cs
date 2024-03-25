using Application.Features.BlackLists.Constants;
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

namespace Application.Features.BlackLists.Commands.Delete;

public class DeleteBlackListCommand
    : IRequest<DeletedBlackListResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, BlackListsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlackLists"];

    public class DeleteBlackListCommandHandler : IRequestHandler<DeleteBlackListCommand, DeletedBlackListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlackListRepository _blackListRepository;
        private readonly BlackListBusinessRules _blackListBusinessRules;

        public DeleteBlackListCommandHandler(
            IMapper mapper,
            IBlackListRepository blackListRepository,
            BlackListBusinessRules blackListBusinessRules
        )
        {
            _mapper = mapper;
            _blackListRepository = blackListRepository;
            _blackListBusinessRules = blackListBusinessRules;
        }

        public async Task<DeletedBlackListResponse> Handle(DeleteBlackListCommand request, CancellationToken cancellationToken)
        {
            BlackList? blackList = await _blackListRepository.GetAsync(
                predicate: bl => bl.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _blackListBusinessRules.BlackListShouldExistWhenSelected(blackList);

            await _blackListRepository.DeleteAsync(blackList!);

            DeletedBlackListResponse response = _mapper.Map<DeletedBlackListResponse>(blackList);
            return response;
        }
    }
}
