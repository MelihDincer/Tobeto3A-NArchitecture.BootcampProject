namespace Domain.Entities;

public class Employee : User
{
    public string Position { get; set; }

    public Employee() { }

    public Employee(
        Guid id,
        string userName,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string nationalIdentity,
        string email,
        string position,
        byte[] passwordHash,
        byte[] passwordSalt
    )
        : this()
    {
        Id = id;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Position = position;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public Employee(
        string userName,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string nationalIdentity,
        string email,
        string position,
        byte[] passwordHash,
        byte[] passwordSalt
    )
        : this()
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        NationalIdentity = nationalIdentity;
        Email = email;
        Position = position;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
