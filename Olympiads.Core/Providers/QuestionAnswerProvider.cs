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
        _context.QuestionAnswers.Add(questionAnswer);

        await _context.SaveChangesAsync();

        var result = questionAnswer.Id;

        return result;
    }

    public async Task<List<QuestionAnswer>> GetAllQuestionAnswers()
    {
        var result = await _context.QuestionAnswers.ToListAsync();

        if (result is null) throw new EntityNotFoundExpection($"{nameof(QuestionAnswer)} not found");

        return result;
    }

    public async Task<QuestionAnswer> UpdateQuestionAnswer(QuestionAnswer updateQuestionAnswer)
    {
        var result = _context.QuestionAnswers.Find(updateQuestionAnswer.Id);

        if (result is null) throw new EntityNotFoundExpection($"{nameof(QuestionAnswer)} not found");

        result.ChangeValue(updateQuestionAnswer);

        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<int> DeleteQuestionAnswer(int id)
    {
        var answer = _context.QuestionAnswers.Find(id);

        if (answer is null) throw new EntityNotFoundExpection($"{nameof(QuestionAnswer)} not found");

        _context.QuestionAnswers.Remove(answer);
        await _context.SaveChangesAsync();

        var result = answer.Id;

        return result;
    }
}
