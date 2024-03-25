using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlackLists.Commands.Delete;

public class DeletedBlackListResponse : IResponse
{
    public int Id { get; set; }
}