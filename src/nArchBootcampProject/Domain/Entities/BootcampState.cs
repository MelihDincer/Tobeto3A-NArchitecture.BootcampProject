using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BootcampState : Entity<short>
{
    public string Name { get; set; }
    public virtual ICollection<Bootcamp> Bootcamps { get; set; }

    public BootcampState()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }

    public BootcampState(short id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }

    public BootcampState(string name)
        : this()
    {
        Name = name;
    }
}
