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

namespace Application.Features.BlackLists.Commands.Create;

public class CreateBlackListCommand
    : IRequest<CreatedBlackListResponse>,
        ISecuredRequest,
        ICacheRemoverRequest,
        ILoggableRequest,
        ITransactionalRequest
{
    public Guid ApplicantId { get; set; }
    public string? Reason { get; set; }
    public DateTime Date { get; set; }

    public string[] Roles => [Admin, Write, BlackListsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlackLists"];

    public class CreateBlackListCommandHandler : IRequestHandler<CreateBlackListCommand, CreatedBlackListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlackListRepository _blackListRepository;
        private readonly BlackListBusinessRules _blackListBusinessRules;

        public CreateBlackListCommandHandler(
            IMapper mapper,
            IBlackListRepository blackListRepository,
            BlackListBusinessRules blackListBusinessRules
        )
        {
            _mapper = mapper;
            _blackListRepository = blackListRepository;
            _blackListBusinessRules = blackListBusinessRules;
        }

        public async Task<CreatedBlackListResponse> Handle(CreateBlackListCommand request, CancellationToken cancellationToken)
        {
            BlackList blackList = _mapper.Map<BlackList>(request);

            await _blackListRepository.AddAsync(blackList);

            CreatedBlackListResponse response = _mapper.Map<CreatedBlackListResponse>(blackList);
            return response;
        }
    }
}
