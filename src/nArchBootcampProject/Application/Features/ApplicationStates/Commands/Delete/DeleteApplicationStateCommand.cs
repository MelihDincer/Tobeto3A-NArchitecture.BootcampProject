using Application.Features.ApplicationStates.Constants;
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

namespace Application.Features.ApplicationStates.Commands.Delete;

public class DeleteApplicationStateCommand : IRequest<DeletedApplicationStateResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public short Id { get; set; }

    public string[] Roles => [Admin, Write, ApplicationStatesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetApplicationStates"];

    public class DeleteApplicationStateCommandHandler : IRequestHandler<DeleteApplicationStateCommand, DeletedApplicationStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly ApplicationStateBusinessRules _applicationStateBusinessRules;

        public DeleteApplicationStateCommandHandler(IMapper mapper, IApplicationStateRepository applicationStateRepository,
                                         ApplicationStateBusinessRules applicationStateBusinessRules)
        {
            _mapper = mapper;
            _applicationStateRepository = applicationStateRepository;
            _applicationStateBusinessRules = applicationStateBusinessRules;
        }

        public async Task<DeletedApplicationStateResponse> Handle(DeleteApplicationStateCommand request, CancellationToken cancellationToken)
        {
            ApplicationState? applicationState = await _applicationStateRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationStateBusinessRules.ApplicationStateShouldExistWhenSelected(applicationState);

            await _applicationStateRepository.DeleteAsync(applicationState!);

            DeletedApplicationStateResponse response = _mapper.Map<DeletedApplicationStateResponse>(applicationState);
            return response;
        }
    }
}