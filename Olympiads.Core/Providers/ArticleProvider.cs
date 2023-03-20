using Olympiads.Core.Exceptions;
using Olympiads.Core.Interfaces;
using Olympiads.Core.Models;

namespace Olympiads.Core.Providers;

public class ArticleProvider
{
    private readonly IEntityDbContext _context;

    public ArticleProvider(IEntityDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddArticle(Article article)
    {
        _context.Articles.Add(article);
        await _context.SaveChangesAsync();
        return article.Id;
    }

    public async Task<int> RemoveArticle(Article article)
    {
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        return article.Id;
    }

    public async Task<int> UpdateArticle(Article articleForUpdate)
    {
        var article = _context.Articles.Find(articleForUpdate.Id);
        if (article is null) throw new EntityNotFoundExpection($"{nameof(Article)} not found");
        article.Title = articleForUpdate.Title;
        article.Content = articleForUpdate.Content;

        await _context.SaveChangesAsync();
        return article.Id;
    }

    public async Task<List<Article>> GetArticles()
    {
        var result = _context.Articles.ToList();
        if (result is null) throw new EntityNotFoundExpection($"{nameof(Article)} not found");
        return result;
    }
}
