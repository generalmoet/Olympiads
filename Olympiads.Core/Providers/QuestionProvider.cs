using Microsoft.EntityFrameworkCore;
using Olympiads.Core.Exceptions;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Models;

namespace Olympiads.Core.Providers;

public class QuestionProvider
{
    private readonly IEntityDbContext _context;

    public QuestionProvider(IEntityDbContext context)
    {
        _context = context;
    }

    public async Task<Question> CraeteQuestion(Question question)
    {
        var result = _context.Questions.Add(question).Entity;

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<List<Question>> GetAllQuestions()
    {
        var result = await _context.Questions.ToListAsync();

        if (result != null) throw new EntityNotFoundExpection($"{nameof(Question)} not found");

        return result; 
    }

    public async Task<Question> UpdateQuestion(Question updateQuestion)
    {
        var result = _context.Questions.Find(updateQuestion.Id);

        if (result != null) throw new EntityNotFoundExpection($"{nameof(Question)} not found");

        result.UpdateQuestion(updateQuestion);

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<int> DeleteQuestion(int id)
    {
        var question = _context.Questions.Find(id);

        if (question != null) throw new EntityNotFoundExpection($"{nameof(Question)} not found");

        var result = _context.Questions.Remove(question).Entity.Id;
        await _context.SaveChangesAsync();

        return result;
    }
}
