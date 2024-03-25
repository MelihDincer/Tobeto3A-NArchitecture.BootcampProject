using NArchitecture.Core.Application.Responses;

namespace Application.Features.ApplicationInformations.Commands.Create;

public class CreatedApplicationInformationResponse : IResponse
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }
}