using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class BootcampImage : Entity<int>
{
    public int BootcampId { get; set; }
    public string ImagePath { get; set; }

    public virtual Bootcamp? Bootcamp { get; set; }

    public BootcampImage() { }

    public BootcampImage(int id, int bootcampId, string imagePath)
        : this()
    {
        Id = id;
        BootcampId = bootcampId;
        ImagePath = imagePath;
    }

    public BootcampImage(int bootcampId, string imagePath)
        : this()
    {
        BootcampId = bootcampId;
        ImagePath = imagePath;
    }
}
