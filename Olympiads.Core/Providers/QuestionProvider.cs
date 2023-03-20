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

    public async Task<int> CraeteQuestion(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        var result = question.Id;

        return result;
    }

    public async Task<List<Question>> GetAllQuestions()
    {
        var result = await _context.Questions.ToListAsync();

        if (result is null) throw new EntityNotFoundExpection($"{nameof(Question)} not found");

        return result; 
    }

    public async Task<Question> UpdateQuestion(Question updateQuestion)
    {
        var result = _context.Questions.Find(updateQuestion.Id);

        if (result is null) throw new EntityNotFoundExpection($"{nameof(Question)} not found");

        result.UpdateQuestion(updateQuestion);

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<int> DeleteQuestion(int id)
    {
        var question = _context.Questions.Find(id);

        if (question is null) throw new EntityNotFoundExpection($"{nameof(Question)} not found");

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();

        var result = question.Id;

        return result;
    }
}
