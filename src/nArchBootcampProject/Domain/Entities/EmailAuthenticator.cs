using NArchitecture.Core.Security.Entities;

namespace Domain.Entities;

public class EmailAuthenticator : EmailAuthenticator<Guid>
{
    public virtual User User { get; set; } = default!;
}
