using Application.Features.BlackLists.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.BlackLists.Constants.BlackListsOperationClaims;

namespace Application.Features.BlackLists.Queries.GetList;

public class GetListBlackListQuery : IRequest<GetListResponse<GetListBlackListListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBlackLists({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBlackLists";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBlackListQueryHandler
        : IRequestHandler<GetListBlackListQuery, GetListResponse<GetListBlackListListItemDto>>
    {
        private readonly IBlackListRepository _blackListRepository;
        private readonly IMapper _mapper;

        public GetListBlackListQueryHandler(IBlackListRepository blackListRepository, IMapper mapper)
        {
            _blackListRepository = blackListRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBlackListListItemDto>> Handle(
            GetListBlackListQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<BlackList> blackLists = await _blackListRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBlackListListItemDto> response = _mapper.Map<GetListResponse<GetListBlackListListItemDto>>(
                blackLists
            );
            return response;
        }
    }
}
