using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ApplicationInformations.Queries.GetList;

public class GetListApplicationInformationListItemDto : IDto
{
    public int Id { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public string ApplicantEmail { get; set; }
    public string BootcampName { get; set; }
    public string ApplicationStateName { get; set; }
}
