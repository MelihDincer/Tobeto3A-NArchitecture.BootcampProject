using Application.Features.BlackLists.Constants;
using Application.Features.BlackLists.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BlackLists.Constants.BlackListsOperationClaims;

namespace Application.Features.BlackLists.Queries.GetById;

public class GetByIdBlackListQuery : IRequest<GetByIdBlackListResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBlackListQueryHandler : IRequestHandler<GetByIdBlackListQuery, GetByIdBlackListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlackListRepository _blackListRepository;
        private readonly BlackListBusinessRules _blackListBusinessRules;

        public GetByIdBlackListQueryHandler(IMapper mapper, IBlackListRepository blackListRepository, BlackListBusinessRules blackListBusinessRules)
        {
            _mapper = mapper;
            _blackListRepository = blackListRepository;
            _blackListBusinessRules = blackListBusinessRules;
        }

        public async Task<GetByIdBlackListResponse> Handle(GetByIdBlackListQuery request, CancellationToken cancellationToken)
        {
            BlackList? blackList = await _blackListRepository.GetAsync(predicate: bl => bl.Id == request.Id, cancellationToken: cancellationToken);
            await _blackListBusinessRules.BlackListShouldExistWhenSelected(blackList);

            GetByIdBlackListResponse response = _mapper.Map<GetByIdBlackListResponse>(blackList);
            return response;
        }
    }
}