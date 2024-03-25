using NArchitecture.Core.Security.Entities;

namespace Domain.Entities;

public class OtpAuthenticator : OtpAuthenticator<Guid>
{
    public virtual User User { get; set; } = default!;
}
