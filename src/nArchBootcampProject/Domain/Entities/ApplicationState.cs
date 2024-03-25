using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class ApplicationState : Entity<short>
{
    public string Name { get; set; }
    public virtual ICollection<ApplicationInformation> ApplicationInformations { get; set; }

    public ApplicationState()
    {
        ApplicationInformations = new HashSet<ApplicationInformation>();
    }

    public ApplicationState(short id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }

    public ApplicationState(string name)
        : this()
    {
        Name = name;
    }
}
