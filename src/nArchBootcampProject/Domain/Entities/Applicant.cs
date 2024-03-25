namespace Domain.Entities;

public class Applicant : User
{
    public string About { get; set; }
    public virtual BlackList? BlackList { get; set; }
    public virtual ICollection<ApplicationInformation> Applications { get; set; }

    public Applicant()
    {
        Applications = new HashSet<ApplicationInformation>();
    }

    public Applicant(Guid id, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity,
        string email, string about, byte[] passwordHash, byte[] passwordSalt) : this()
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        About = about;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public Applicant(string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity,
        string email, string about, byte[] passwordHash, byte[] passwordSalt) : this()
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        About = about;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}