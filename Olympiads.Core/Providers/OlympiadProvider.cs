using Microsoft.EntityFrameworkCore;
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
        if (_context.Olympiad.Count() > 1) throw new Exception("To much olympiads");
        olympiad.StartTime = olympiad.StartTime.ToUniversalTime();
        olympiad.EndTime = olympiad.EndTime.ToUniversalTime();
        olympiad.StartRegistrationTime = olympiad.StartRegistrationTime.ToUniversalTime();
        olympiad.EndRegistrationTime = olympiad.EndRegistrationTime.ToUniversalTime();
        _context.Olympiad.Add(olympiad);

        await _context.SaveChangesAsync();

        var result = olympiad.Id;
        return result;
    }

    public async Task<Olympiad> GetOlympiad()
    {
        var result = await _context.Olympiad.Include(o => o.Questions).ThenInclude(q => q.QuestionAnswers).Include(o => o.Questions).ThenInclude(q => q.StudentAnswers).FirstOrDefaultAsync();

        if (result is null) throw new EntityNotFoundExpection($"{nameof(Olympiad)} not found");

        return result;
    }

    public async Task<Olympiad> UpdateOlympiad(Olympiad olympiad)
    {
        var changingOlympiad = await _context.Olympiad.FindAsync(olympiad.Id);

        if (changingOlympiad is null) throw new EntityNotFoundExpection($"{nameof(Olympiad)} not found");

        changingOlympiad.Name = olympiad.Name;
        changingOlympiad.Description = olympiad.Description;
        changingOlympiad.StartTime = olympiad.StartTime;
        changingOlympiad.EndTime = olympiad.EndTime;
        changingOlympiad.StartRegistrationTime = olympiad.StartRegistrationTime;
        changingOlympiad.EndRegistrationTime = olympiad.EndRegistrationTime;

        await _context.SaveChangesAsync();

        return changingOlympiad;
    }

    public async Task<int> DeleteOlympliad(int id)
    {
        var deletingOlympiad = await _context.Olympiad.FindAsync(id);

        if (deletingOlympiad is null) throw new EntityNotFoundExpection($"{nameof(Olympiad)} not found");

        _context.Olympiad.Remove(deletingOlympiad);

        await _context.SaveChangesAsync();

        var result = deletingOlympiad.Id;

        return result;
    }
}
