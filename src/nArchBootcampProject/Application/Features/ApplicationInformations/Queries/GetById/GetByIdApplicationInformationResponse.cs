using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationInformations.Queries.GetById;

public class GetByIdApplicationInformationResponse : IResponse
{
    public int Id { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public string ApplicantEmail { get; set; }
    public string BootcampName { get; set; }
    public string ApplicationStateName { get; set; }
}
