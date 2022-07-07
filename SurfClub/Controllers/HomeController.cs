using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfClub.Models;
using System.Diagnostics;

namespace SurfClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClubContext _context;

        public HomeController(ILogger<HomeController> logger, ClubContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var posts = _context.Posts
                .Include(p => p.Author)
                .ToList();
            ViewBag.Posts = posts;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}