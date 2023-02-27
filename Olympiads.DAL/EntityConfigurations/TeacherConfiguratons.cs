using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympiads.Core.Models;

namespace Olympiads.DAL.EntityConfigurations;

public class TeacherConfiguratons : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasOne(t => t.Team)
            .WithOne(t => t.Teacher)
            .HasForeignKey<Team>(t => t.TeacherId);
    }
}
