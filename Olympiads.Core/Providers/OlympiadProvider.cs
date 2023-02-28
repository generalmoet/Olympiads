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
        var result = _context.Olympiad.Add(olympiad).Entity.Id;

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<Olympiad> GetOlympiad(int id)
    {
        var result = _context.Olympiad.Include("Questions").Include("QuestionAnswers").FirstOrDefault();

        if (result != null) throw new EntityNotFoundExpection($"{nameof(Olympiad)} not found");

        return result;
    }

    public async Task<Olympiad> UpdateOlympiad(Olympiad olympiad)
    {
        var changingOlympiad = await _context.Olympiad.FindAsync(olympiad.Id);

        if (changingOlympiad != null) throw new EntityNotFoundExpection($"{nameof(Olympiad)} not found");

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

        if (deletingOlympiad != null) throw new EntityNotFoundExpection($"{nameof(Olympiad)} not found");

        var result = _context.Olympiad.Remove(deletingOlympiad).Entity.Id;

        await _context.SaveChangesAsync();

        return result;
    }
}
