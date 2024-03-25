using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BlackListConfiguration : IEntityTypeConfiguration<BlackList>
{
    public void Configure(EntityTypeBuilder<BlackList> builder)
    {
        builder.ToTable("BlackLists").HasKey(bl => bl.Id);

        builder.Property(bl => bl.Id).HasColumnName("Id").IsRequired();
        builder.Property(bl => bl.ApplicantId).HasColumnName("ApplicantId");
        builder.Property(bl => bl.Reason).HasColumnName("Reason");
        builder.Property(bl => bl.Date).HasColumnName("Date");
        builder.Property(bl => bl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bl => bl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bl => bl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.Applicant);
        builder.HasQueryFilter(bl => !bl.DeletedDate.HasValue);
    }
}
