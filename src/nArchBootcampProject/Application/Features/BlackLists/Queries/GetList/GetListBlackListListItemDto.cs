using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BlackLists.Queries.GetList;

public class GetListBlackListListItemDto : IDto
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public string? Reason { get; set; }
    public DateTime Date { get; set; }
}
