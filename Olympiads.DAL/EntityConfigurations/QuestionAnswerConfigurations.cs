using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympiads.Core.Models;

namespace Olympiads.DAL.EntityConfigurations;

public class QuestionAnswerConfigurations : IEntityTypeConfiguration<QuestionAnswer>
{
    public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
    {
        builder.HasKey(q => q.Id);
        builder.HasOne<Question>()
            .WithMany(q => q.QuestionAnswers)
            .HasForeignKey(q => q.QuestionId);
    }
}
