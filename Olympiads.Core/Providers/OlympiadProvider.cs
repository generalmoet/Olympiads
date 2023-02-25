using Olympiads.Core.Exceptions;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Models;

namespace Olympiads.Core.Providers;

public class OlympiadProvider
{
    private readonly IEntityDbContext _context;

    public OlympiadProvider(IEntityDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CreateOlympiad(Olympiad olympiad)
    {
        var result = _context.Olympiad.Add(olympiad).Entity.Id;
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<Olympiad> GetOlympiad(int id)
    {
        return await _context.Olympiad.FindAsync(id);
    }

    public async Task<Olympiad> UpdateOlympiad(Olympiad olympiad)
    {
        var changingOlympiad = await _context.Olympiad.FindAsync(olympiad.Id);

        if (changingOlympiad != null) throw new EntityNotFoundExpection("Entity not found");

        changingOlympiad.Name = olympiad.Name;
        changingOlympiad.Description = olympiad.Description;
        changingOlympiad.StartTime = olympiad.StartTime;
        changingOlympiad.EndTime = olympiad.EndTime;
        changingOlympiad.StartRegistrationTime = olympiad.StartRegistrationTime;
        changingOlympiad.EndRegistrationTime = olympiad.EndRegistrationTime;

        await _context.SaveChangesAsync();

        return changingOlympiad;
    }

}
