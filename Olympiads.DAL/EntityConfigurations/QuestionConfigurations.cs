using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympiads.Core.Models;

namespace Olympiads.DAL.EntityConfigurations;

public class QuestionConfigurations : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);
        builder.HasOne<Olympiad>()
            .WithMany(q => q.Questions)
            .HasForeignKey(q => q.OlympiadId);
    }
}
