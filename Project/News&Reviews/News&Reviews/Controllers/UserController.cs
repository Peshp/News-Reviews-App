using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.DataModels.UserModels;
using News_Reviews.Models.UserModels;

namespace News_Reviews.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (UserIsLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }

            RegisterViewModel model = new();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new()
            {
                UserName = model.Username,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (UserIsLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }

            LoginViewModel model = new();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.Username);
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("All", "Books");
            }

            ModelState.AddModelError(string.Empty, "Login failed");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool UserIsLoggedIn()
            => User?.Identity?.IsAuthenticated ?? false;
    }
}
