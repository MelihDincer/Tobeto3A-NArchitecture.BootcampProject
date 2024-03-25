namespace Domain.Entities;

public class Instructor : User
{
    public string CompanyName { get; set; }
    public virtual ICollection<Bootcamp> Bootcamps { get; set; }

    public Instructor()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }

    public Instructor(Guid id, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity,
        string email, string companyName, byte[] passwordHash, byte[] passwordSalt) : this()
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        CompanyName = companyName;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public Instructor(string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity,
        string email, string companyName, byte[] passwordHash, byte[] passwordSalt) : this()
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        CompanyName = companyName;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}