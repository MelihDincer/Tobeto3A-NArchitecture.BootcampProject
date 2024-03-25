using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStates.Commands.Delete;

public class DeletedApplicationStateResponse : IResponse
{
    public short Id { get; set; }
}