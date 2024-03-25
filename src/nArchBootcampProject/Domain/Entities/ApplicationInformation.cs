using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ApplicationInformation : Entity<int>
{
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public int ApplicationStateId { get; set; }
    public virtual Applicant? Applicant { get; set; }
    public virtual Bootcamp? Bootcamp { get; set; }
    public virtual ApplicationState? ApplicationState { get; set; }

    public ApplicationInformation()
    {
        
    }

    public ApplicationInformation(int id, int applicantId, int bootcampId, int applicationStatedId) : this()
    {
        Id = id;
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationStateId = applicationStatedId;
    }

    public ApplicationInformation(int applicantId, int bootcampId, int applicationStatedId) : this()
    {
        ApplicantId = applicantId;
        BootcampId = bootcampId;
        ApplicationStateId = applicationStatedId;
    }
}
