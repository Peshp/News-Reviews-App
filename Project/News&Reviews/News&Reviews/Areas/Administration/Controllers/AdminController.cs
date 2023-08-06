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
            var roleId = "0a1c1685-c05d-4186-a1a0-fbaebdb7ae79";

            ApplicationUserModel mod;

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

        [HttpPost]
        public async Task<IActionResult> Add(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                TempData["Message"] = "User not found";
                return RedirectToAction(nameof(All));
            }

            var result = await userManager.AddToRoleAsync(user, "Moderator");
            if (result.Succeeded)
            {
                TempData["Message"] = "Moderator role added successfully.";
            }
            else
            {
                TempData["Message"] = "Failed to add Moderator role to the user.";
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Remove(string id)
        {
            var user = await context.Users
                .FindAsync(id);

            if (user != null)
            {
                var result = await userManager.RemoveFromRoleAsync(user, "Moderator");
            }          

            return RedirectToAction(nameof(All));
        }
    }
}
