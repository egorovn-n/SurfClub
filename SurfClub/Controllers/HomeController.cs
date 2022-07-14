using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfClub.Helpers;
using SurfClub.Models;
using System.Security.Claims;

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
            SetPostsToViewBag();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SavePost(Post newPost, IFormFile? photo)
        {
            if((newPost == null || string.IsNullOrEmpty(newPost.Text))
                && photo == null)
            {
                SetPostsToViewBag();
                return View("Index", newPost);
            }

            if (photo != null)
            {
                var extension = Path.GetExtension(photo.FileName);
                if (extension.ToLower() != ".jpg" && extension.ToLower() != ".jpeg"
                    && extension.ToLower() != ".png")
                {
                    return RedirectToAction("Index");
                }
                var imageHelper = new ImageHelper();
                newPost.Photo = await imageHelper.UploadImage(photo);
            }

            newPost.CreateDate = DateTime.Now;
            newPost.AuthorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            _context.Posts.Add(newPost);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private void SetPostsToViewBag()
        {
            List<Post> posts = _context.Posts
                .Include(p => p.Author)
                .OrderByDescending(p => p.CreateDate)
                .ToList();
            ViewBag.Posts = posts;
        }
    }
}