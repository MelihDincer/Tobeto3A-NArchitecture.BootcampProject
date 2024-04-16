namespace Application.Features.Auth.Commands.Register;

public class RegisterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
}
