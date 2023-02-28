using Microsoft.EntityFrameworkCore;
using Olympiads.Core.Models;
using Olympiads.Core.Models.Abstractions;

namespace Olympiads.Core.Interfaces;

public interface IEntityDbContext
{
    public DbSet<Olympiad> Olympiad { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<StudentAnswer> StudentAnswers { get; set; }
    public Task<int> SaveChangesAsync();
}
