using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Account;
using News_Reviews.Services.Interfaces;

namespace News_Reviews.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IForumService forumService;
        private readonly IReviewsService reviewsService;

        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> DisplayProfile()
        {
            var user = await userManager.GetUserAsync(User);

            DisplayProfileViewModel model = new DisplayProfileViewModel()
            {
                UserId = user.Id,
                Username = user.UserName,
                Password = user.PasswordHash,
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var model = new EditProfileFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(EditProfileFormModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);

            var changePassword = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!changePassword.Succeeded)
            {
                foreach (var error in changePassword.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await signInManager.RefreshSignInAsync(user);

            return RedirectToAction(nameof(DisplayProfile));
        }
    }
}
