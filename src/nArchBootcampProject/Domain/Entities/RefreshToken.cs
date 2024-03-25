using NArchitecture.Core.Security.Entities;

namespace Domain.Entities;

public class RefreshToken : RefreshToken<Guid>
{
    public virtual User User { get; set; } = default!;
}
