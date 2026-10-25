using EnterpriseBlogCMS.Models;
using EnterpriseBlogCMS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseBlogCMS.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleRepository _repository;

        public ArticlesController(IArticleRepository repository)
        {
            _repository = repository;
        }

        // Main Blog Dashboard (React.js + MVC Hybrid View)
        public async Task<IActionResult> Index(string? search, string? category)
        {
            var articles = await _repository.GetAllAsync(search, category);
            return View(articles);
        }

        // JSON API endpoint for React.js dynamic search & filtering
        [HttpGet("/api/articles")]
        public async Task<IActionResult> GetArticlesApi(string? search, string? category)
        {
            var articles = await _repository.GetAllAsync(search, category);
            return Ok(articles);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create() => View();

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            if (!ModelState.IsValid) return View(article);

            article.AuthorName = User.Identity?.Name ?? "Admin";
            article.CreatedAt = DateTime.UtcNow;
            await _repository.AddAsync(article);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}