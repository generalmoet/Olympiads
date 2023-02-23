using Microsoft.EntityFrameworkCore;
using Olympiads.Core.Models;

namespace Olympiads.Core.Interfaces;

public interface IEntityDbContext : IDisposable
{
    DbSet<Olympiad> Olympiad { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<OlympiadTeam> Teams { get; set; }
    DbSet<Question> Question { get; set; }
    DbSet<QuestionResponse> QuestionResponses { get; set; }
    public Task<int> SaveChangesAsync();
}
