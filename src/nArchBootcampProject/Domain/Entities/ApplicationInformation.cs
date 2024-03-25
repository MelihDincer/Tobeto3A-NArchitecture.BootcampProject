using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ApplicationInformation : Entity<int>
{
    public Guid ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public short ApplicationStateId { get; set; }
    public virtual Applicant? Applicant { get; set; }
    public virtual Bootcamp? Bootcamp { get; set; }
    public virtual ApplicationState? ApplicationState { get; set; }

    public ApplicationInformation() { }

    public ApplicationInformation(int id, Guid applicantId, int bootcampId, short applicationStatedId)
        : this()
    {
        Id = id;
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationStateId = applicationStatedId;
    }

    public ApplicationInformation(Guid applicantId, int bootcampId, short applicationStatedId)
        : this()
    {
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationStateId = applicationStatedId;
    }
}
