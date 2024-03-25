using Application.Features.ApplicationStates.Constants;
using Application.Features.ApplicationStates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ApplicationStates.Constants.ApplicationStatesOperationClaims;

namespace Application.Features.ApplicationStates.Commands.Create;

public class CreateApplicationStateCommand : IRequest<CreatedApplicationStateResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, ApplicationStatesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationStates"];

    public class CreateApplicationStateCommandHandler : IRequestHandler<CreateApplicationStateCommand, CreatedApplicationStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly ApplicationStateBusinessRules _applicationStateBusinessRules;

        public CreateApplicationStateCommandHandler(IMapper mapper, IApplicationStateRepository applicationStateRepository,
                                         ApplicationStateBusinessRules applicationStateBusinessRules)
        {
            _mapper = mapper;
            _applicationStateRepository = applicationStateRepository;
            _applicationStateBusinessRules = applicationStateBusinessRules;
        }

        public async Task<CreatedApplicationStateResponse> Handle(CreateApplicationStateCommand request, CancellationToken cancellationToken)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);

            await _applicationStateRepository.AddAsync(applicationState);

            CreatedApplicationStateResponse response = _mapper.Map<CreatedApplicationStateResponse>(applicationState);
            return response;
        }
    }
}