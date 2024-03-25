using Application.Features.ApplicationStates.Constants;
using Application.Features.ApplicationStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ApplicationStates.Constants.ApplicationStatesOperationClaims;

namespace Application.Features.ApplicationStates.Queries.GetById;

public class GetByIdApplicationStateQuery : IRequest<GetByIdApplicationStateResponse>, ISecuredRequest
{
    public short Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdApplicationStateQueryHandler : IRequestHandler<GetByIdApplicationStateQuery, GetByIdApplicationStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly ApplicationStateBusinessRules _applicationStateBusinessRules;

        public GetByIdApplicationStateQueryHandler(IMapper mapper, IApplicationStateRepository applicationStateRepository, ApplicationStateBusinessRules applicationStateBusinessRules)
        {
            _mapper = mapper;
            _applicationStateRepository = applicationStateRepository;
            _applicationStateBusinessRules = applicationStateBusinessRules;
        }

        public async Task<GetByIdApplicationStateResponse> Handle(GetByIdApplicationStateQuery request, CancellationToken cancellationToken)
        {
            ApplicationState? applicationState = await _applicationStateRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationStateBusinessRules.ApplicationStateShouldExistWhenSelected(applicationState);

            GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
            return response;
        }
    }
}