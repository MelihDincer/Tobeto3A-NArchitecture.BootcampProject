using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BlackList : Entity<int>
{
    public Guid ApplicantId { get; set; }
    public string? Reason { get; set; }
    public DateTime Date { get; set; }
    public virtual Applicant? Applicant { get; set; }

    public BlackList() { }

    public BlackList(int id, Guid applicantId, string reason, DateTime dateTime)
        : this()
    {
        Id = id;
        ApplicantId = applicantId;
        Reason = reason;
        Date = dateTime;
    }

    public BlackList(Guid applicantId, string reason, DateTime dateTime)
        : this()
    {
        ApplicantId = applicantId;
        Reason = reason;
        Date = dateTime;
    }
}
