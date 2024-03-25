using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationStates.Queries.GetById;

public class GetByIdApplicationStateResponse : IResponse
{
    public short Id { get; set; }
    public string Name { get; set; }
}