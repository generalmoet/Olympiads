using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympiads.Core.Models;

namespace Olympiads.DAL.EntityConfigurations;

public class TeacherConfiguratons : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(teacher => teacher.Id);
        builder.HasOne(teacher => teacher.Team)
            .WithOne(team => team.Teacher)
            .HasForeignKey<Team>(team => team.TeacherId);
    }
}
