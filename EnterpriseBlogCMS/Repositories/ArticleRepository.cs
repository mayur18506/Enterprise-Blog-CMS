using EnterpriseBlogCMS.Data;
using EnterpriseBlogCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseBlogCMS.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllAsync(string? search, string? category);
        Task<Article?> GetByIdAsync(int id);
        Task AddAsync(Article article);
        Task UpdateAsync(Article article);
        Task DeleteAsync(int id);
    }

    public class ArticleRepository : IArticleRepository
    {
        private readonly BlogDbContext _context;

        public ArticleRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetAllAsync(string? search, string? category)
        {
            var query = _context.Articles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(a => a.Title.Contains(search) || a.Content.Contains(search));

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(a => a.Category == category);

            return await query.OrderByDescending(a => a.CreatedAt).ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(int id) => await _context.Articles.FindAsync(id);

        public async Task AddAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }
    }
}