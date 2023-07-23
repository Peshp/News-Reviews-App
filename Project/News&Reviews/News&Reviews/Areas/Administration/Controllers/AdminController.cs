using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.DataModels;

namespace News_Reviews.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public AdminController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<IActionResult> MakeMod(string username)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await userManager.AddToRoleAsync(user, "Moderator");

            return Ok($"Role moderator is successfull added to {username}");
        }
    }
}
