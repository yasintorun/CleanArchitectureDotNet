using LMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMS.Infrastructure.Database.EntityFramework.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Identity).HasMaxLength(11).IsRequired();
        builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();
    }
}
