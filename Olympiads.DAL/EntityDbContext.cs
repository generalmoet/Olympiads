using Microsoft.EntityFrameworkCore;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Models;

namespace Olympiads.DAL;

public class EntityDbContext : DbContext, IEntityDbContext
{ 
    public DbSet<Olympiad> Olympiad { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OlympiadTeam> Teams { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<QuestionResponse> QuestionResponses { get; set; }

    public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Olympiad>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Question>()
            .HasKey(q => q.Id);

        modelBuilder.Entity<QuestionResponse>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<User>()
            .HasOne<OlympiadTeam>()
            .WithMany(u => u.Users)
            .HasForeignKey(u => u.TeamId);

        modelBuilder.Entity<Question>()
            .HasOne<Olympiad>()
            .WithMany(q => q.Questions)
            .HasForeignKey(q => q.OlympiadId);

        modelBuilder.Entity<QuestionResponse>()
            .HasOne<Question>()
            .WithMany(r => r.QuestionResponses)
            .HasForeignKey(r => r.QuestionId);

        base.OnModelCreating(modelBuilder);
    }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}