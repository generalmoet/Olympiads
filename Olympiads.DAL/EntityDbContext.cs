using Microsoft.EntityFrameworkCore;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Models;
using Olympiads.Core.Models.Abstractions;
using Olympiads.DAL.EntityConfigurations;
using System.Reflection;

namespace Olympiads.DAL;

public class EntityDbContext : DbContext, IEntityDbContext
{ 
    public DbSet<Olympiad> Olympiad { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<Article> Articles { get; set; }

    public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
            t => t.GetInterfaces().Any(i =>i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }
}