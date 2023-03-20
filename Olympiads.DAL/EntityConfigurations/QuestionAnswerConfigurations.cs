using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympiads.Core.Models;

namespace Olympiads.DAL.EntityConfigurations;

public class QuestionAnswerConfigurations : IEntityTypeConfiguration<QuestionAnswer>
{
    public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
    {
        builder.HasKey(answer => answer.Id);
        builder.HasOne<Question>()
            .WithMany(question => question.QuestionAnswers)
            .HasForeignKey(answer => answer.QuestionId);
    }
}
