using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationInformations.Commands.Update;

public class UpdatedApplicationInformationResponse : IResponse
{
    public int Id { get; set; }
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }
}
