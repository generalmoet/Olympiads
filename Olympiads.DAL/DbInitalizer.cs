using Microsoft.EntityFrameworkCore;

namespace Olympiads.DAL;

public class DbInitializer
{
    public static void Initialize(EntityDbContext context)
    {
        context.Database.Migrate();
    }
}