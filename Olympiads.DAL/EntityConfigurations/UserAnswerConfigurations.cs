using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympiads.Core.Models;

namespace Olympiads.DAL.EntityConfigurations;

public class UserAnswerConfigurations : IEntityTypeConfiguration<UserAnswer>
{
    public void Configure(EntityTypeBuilder<UserAnswer> builder)
    {
        builder.HasOne<Question>()
            .WithMany(question => question.StudentAnswers)
            .HasForeignKey(answer => answer.QuestionId);

        builder.HasOne<User>()
            .WithMany(user => user.Answers)
            .HasForeignKey(answer => answer.StudentId);
    }
}
