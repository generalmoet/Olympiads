using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olympiads.Core.Models;

namespace Olympiads.DAL.EntityConfigurations;

public class OlympiadConfigurations : IEntityTypeConfiguration<Olympiad>
{
    public void Configure(EntityTypeBuilder<Olympiad> builder)
    {
        builder.HasKey(o => o.Id);
    }
}
