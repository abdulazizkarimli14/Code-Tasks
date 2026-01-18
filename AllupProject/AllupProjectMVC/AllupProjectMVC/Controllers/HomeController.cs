using AllupProjectMVC.Data;
using AllupProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AllupProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
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
