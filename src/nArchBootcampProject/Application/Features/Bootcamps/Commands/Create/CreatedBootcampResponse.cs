using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bootcamps.Commands.Create;

public class CreatedBootcampResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public int BootcampStateId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}