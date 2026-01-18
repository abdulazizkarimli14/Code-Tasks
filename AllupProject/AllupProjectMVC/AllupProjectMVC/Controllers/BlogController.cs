using AllupProjectMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace AllupProjectMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var blogs = _context.Blogs
                .OrderByDescending(b => b.CreatedAt)
                .ToList();

            return View(blogs);
        }
    }
}
