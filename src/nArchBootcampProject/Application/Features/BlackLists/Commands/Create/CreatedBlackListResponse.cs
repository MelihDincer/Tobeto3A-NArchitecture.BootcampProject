using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlackLists.Commands.Create;

public class CreatedBlackListResponse : IResponse
{
    public int Id { get; set; }
    public string ApplicantUserName { get; set; }
    public string? Reason { get; set; }
    public DateTime Date { get; set; }
}
