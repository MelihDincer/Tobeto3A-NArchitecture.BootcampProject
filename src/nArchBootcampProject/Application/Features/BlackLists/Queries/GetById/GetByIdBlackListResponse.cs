using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlackLists.Queries.GetById;

public class GetByIdBlackListResponse : IResponse
{
    public int Id { get; set; }
    public string ApplicantUserName { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public string ApplicantEmail { get; set; }
    public string? Reason { get; set; }
    public DateTime Date { get; set; }
}
