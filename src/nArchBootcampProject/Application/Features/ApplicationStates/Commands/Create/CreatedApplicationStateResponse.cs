using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStates.Commands.Create;

public class CreatedApplicationStateResponse : IResponse
{
    public short Id { get; set; }
    public string Name { get; set; }
}