using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympiads.Core.Models;

namespace Olympiads.DAL.EntityConfigurations;

public class StudentAnswerConfigurations : IEntityTypeConfiguration<StudentAnswer>
{
    public void Configure(EntityTypeBuilder<StudentAnswer> builder)
    {
        builder.HasOne<Question>()
            .WithMany(s => s.StudentAnswers)
            .HasForeignKey(s => s.QuestionId);

        builder.HasOne<Student>()
            .WithMany(s => s.Answers)
            .HasForeignKey(s => s.StudentId);
    }
}
