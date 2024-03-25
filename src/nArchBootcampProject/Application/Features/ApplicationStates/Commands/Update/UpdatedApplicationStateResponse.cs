using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStates.Commands.Update;

public class UpdatedApplicationStateResponse : IResponse
{
    public short Id { get; set; }
    public string Name { get; set; }
}
