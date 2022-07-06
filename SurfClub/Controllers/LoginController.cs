using Microsoft.AspNetCore.Mvc;

namespace SurfClub.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}
