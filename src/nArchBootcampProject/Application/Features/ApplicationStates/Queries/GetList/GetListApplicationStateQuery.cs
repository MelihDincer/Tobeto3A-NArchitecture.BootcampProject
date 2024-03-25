using Application.Features.ApplicationStates.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ApplicationStates.Constants.ApplicationStatesOperationClaims;

namespace Application.Features.ApplicationStates.Queries.GetList;

public class GetListApplicationStateQuery : IRequest<GetListResponse<GetListApplicationStateListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListApplicationStates({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetApplicationStates";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListApplicationStateQueryHandler : IRequestHandler<GetListApplicationStateQuery, GetListResponse<GetListApplicationStateListItemDto>>
    {
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly IMapper _mapper;

        public GetListApplicationStateQueryHandler(IApplicationStateRepository applicationStateRepository, IMapper mapper)
        {
            _applicationStateRepository = applicationStateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationStateListItemDto>> Handle(GetListApplicationStateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ApplicationState> applicationStates = await _applicationStateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListApplicationStateListItemDto> response = _mapper.Map<GetListResponse<GetListApplicationStateListItemDto>>(applicationStates);
            return response;
        }
    }
}