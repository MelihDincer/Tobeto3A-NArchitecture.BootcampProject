using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bootcamps.Commands.Update;

public class UpdatedBootcampResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string InstructorFirstName { get; set; }
    public string InstructorLastName { get; set; }
    public string InstructorCompanyName { get; set; }
    public string BootcampStateName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
