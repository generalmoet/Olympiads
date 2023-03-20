using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympiads.Core.Models;

namespace Olympiads.DAL.EntityConfigurations;

public class StudentAnswerConfigurations : IEntityTypeConfiguration<StudentAnswer>
{
    public void Configure(EntityTypeBuilder<StudentAnswer> builder)
    {
        builder.HasOne<Question>()
            .WithMany(question => question.StudentAnswers)
            .HasForeignKey(answer => answer.QuestionId);

        builder.HasOne<Student>()
            .WithMany(student => student.Answers)
            .HasForeignKey(answer => answer.StudentId);
    }
}
