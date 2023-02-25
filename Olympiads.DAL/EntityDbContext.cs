using Microsoft.EntityFrameworkCore;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Models;
using Olympiads.Core.Models.Abstractions;

namespace Olympiads.DAL;

public class EntityDbContext : DbContext, IEntityDbContext
{ 
    public DbSet<Olympiad> Olympiad { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<StudentAnswer> StudentAnswers { get; set; }

    public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Olympiad>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Student>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Question>()
            .HasKey(q => q.Id);

        modelBuilder.Entity<QuestionAnswer>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<Teacher>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<Student>()
            .HasOne<Team>()
            .WithMany(u => u.Students)
            .HasForeignKey(u => u.TeamId);

        modelBuilder.Entity<Question>()
            .HasOne<Olympiad>()
            .WithMany(q => q.Questions)
            .HasForeignKey(q => q.OlympiadId);

        modelBuilder.Entity<QuestionAnswer>()
            .HasOne<Question>()
            .WithMany(q => q.QuestionAnswers)
            .HasForeignKey(q => q.QuestionId);

        modelBuilder.Entity<StudentAnswer>()
            .HasOne<Question>()
            .WithMany(s => s.StudentAnswers)
            .HasForeignKey(s => s.QuestionId);

        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Team)
            .WithOne(t => t.Teacher)
            .HasForeignKey<Team>(t => t.TeacherId);
        
        modelBuilder.Entity<StudentAnswer>()
            .HasOne<Student>()
            .WithMany(s => s.Answers)
            .HasForeignKey(s => s.StudentId);


        base.OnModelCreating(modelBuilder);
    }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}