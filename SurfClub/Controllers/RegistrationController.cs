using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurfClub.Helpers;
using SurfClub.Models;

namespace SurfClub.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ClubContext _context;

        public RegistrationController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ClubContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Registration(RegistrationViewModel registrationData, IFormFile? photo)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Заполнены не все обязательные поля!");
                return View("Index", registrationData);
            }
            var user = await _userManager.FindByNameAsync(registrationData.UserName);
            if (user != null)
            {
                ModelState.AddModelError("", "Такой псевдоним уже занят!");
                return View("Index", registrationData);
            }
            if (user != null)
            {
                ModelState.AddModelError("", "Такая почта уже зарегистрирована!");
                return View("Index", registrationData);
            }
            if (registrationData.Password != registrationData.ConfirmPassword)
            {
                ModelState.AddModelError("", "Пароли не совпадают");
                return View("Index", registrationData);
            }
            user = new User()
            {
                UserName = registrationData.UserName,
                Email = registrationData.Email,
                LastName = registrationData.LastName,
                FirstName = registrationData.FirstName,
                ContactInfo = registrationData.ContactInfo,
                About = registrationData.About,
                Achievements = registrationData.Achievements
            };

            if (photo != null)
            {
                var imageHelper = new ImageHelper();
                user.Photo = await imageHelper.UploadImage(photo);
            }

            var result = await _userManager.CreateAsync(user, registrationData.Password);
            _context.SaveChanges();
            await _signInManager.SignInAsync(user, isPersistent: false);
            ////Переход на главную страницу
            return RedirectToAction("Index", "Home");
        }
    }
}
