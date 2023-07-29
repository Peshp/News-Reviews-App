using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.Areas.Administration.Models;
using News_Reviews.Data;
using News_Reviews.DataModels;

namespace News_Reviews.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private ApplicationDbContext context;

        public AdminController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            ApplicationDbContext context)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            this.context = context;
        }

        public async Task<IActionResult> All()
        {
            var model = new List<ApplicationUserModel>();
            ApplicationUserModel mod;
            var roleId = "0a1c1685-c05d-4186-a1a0-fbaebdb7ae79"; 

            var usersWithRole = context.UserRoles
                .Where(r => r.RoleId == roleId);

            foreach (var userRole in usersWithRole)
            {
                var user = await userManager.FindByIdAsync(userRole.UserId);

                if (user != null)
                {
                    mod = new ApplicationUserModel
                    {
                        Id = user.Id,
                        Name = user.UserName,
                    };
                    model.Add(mod);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> MakeMod(string username)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await userManager.AddToRoleAsync(user, "Moderator");

            return Ok($"Role moderator is successfull added to {"Tonkata2"}");
        }
    }
}
