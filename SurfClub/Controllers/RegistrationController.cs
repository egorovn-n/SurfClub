using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurfClub.Models;

namespace SurfClub.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegistrationController(
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<ActionResult> Registration(RegistrationViewModel registrationData)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "Неверный псевдоним или пароль!");
            //    return View("Index", loginData);
            //}

            //var user = await _userManager.FindByNameAsync(loginData.UserName);
            ////Поиск юзера
            //if (user == null)
            //{
            //    ModelState.AddModelError("", "Неверный псевдоним или пароль!");
            //    return View("Index", loginData);
            //}

            ////Попытка авторизации
            //var result = await _signInManager.PasswordSignInAsync(user, loginData.Password, loginData.RememberMe, false);
            //if (!result.Succeeded)
            //{
            //    ModelState.AddModelError("", "Неверный псевдоним или пароль!");
            //    return View("Index", loginData);
            //}

            ////Переход на главную страницу
            return RedirectToAction("Index", "Home");
        }
    }
}
