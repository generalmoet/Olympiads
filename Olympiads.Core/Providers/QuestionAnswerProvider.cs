using Microsoft.EntityFrameworkCore;
using Olympiads.Core.Exceptions;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Models;

namespace Olympiads.Core.Providers;

public class QuestionAnswerProvider
{
    private readonly IEntityDbContext _context;

    public QuestionAnswerProvider(IEntityDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateQuestionAnswer(QuestionAnswer questionAnswer)
    {
        var result = _context.QuestionAnswers.Add(questionAnswer).Entity.Id;

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<List<QuestionAnswer>> GetAllQuestionAnswers()
    {
        var result = await _context.QuestionAnswers.ToListAsync();

        if (result != null) throw new EntityNotFoundExpection($"{nameof(QuestionAnswer)} not found");

        return result;
    }

    public async Task<QuestionAnswer> UpdateQuestionAnswer(QuestionAnswer updateQuestionAnswer)
    {
        var result = _context.QuestionAnswers.Find(updateQuestionAnswer.Id);

        if (result != null) throw new EntityNotFoundExpection($"{nameof(QuestionAnswer)} not found");

        result.ChangeValue(updateQuestionAnswer);

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<int> DeleteQuestionAnswer(int id)
    {
        var answer = _context.QuestionAnswers.Find(id);

        if (answer != null) throw new EntityNotFoundExpection($"{nameof(QuestionAnswer)} not found");

        var result = _context.QuestionAnswers.Remove(answer).Entity.Id;
        await _context.SaveChangesAsync();

        return result;
    }
}
