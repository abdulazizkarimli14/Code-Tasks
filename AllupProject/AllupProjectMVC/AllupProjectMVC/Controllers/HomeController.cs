using AllupProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AllupProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
