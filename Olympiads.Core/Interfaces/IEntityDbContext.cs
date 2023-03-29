using Microsoft.EntityFrameworkCore;
using Olympiads.Core.Models;

namespace Olympiads.Core.Interfaces;

public interface IEntityDbContext
{
    public DbSet<Olympiad> Olympiad { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<UserAnswer> StudentAnswers { get; set; }
    public DbSet<Article> Articles { get; set; }
    public Task<int> SaveChangesAsync();
}
