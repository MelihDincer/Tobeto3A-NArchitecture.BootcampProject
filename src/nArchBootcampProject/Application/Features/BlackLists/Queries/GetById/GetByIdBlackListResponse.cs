using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlackLists.Queries.GetById;

public class GetByIdBlackListResponse : IResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string? Reason { get; set; }
    public DateTime Date { get; set; }
}