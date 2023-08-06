using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Account;
using News_Reviews.Services.Interfaces;
using System.Net.NetworkInformation;
using X.PagedList.Mvc.Core;
using X.PagedList;

namespace News_Reviews.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IForumService forumService;
        private readonly ICommentService commentService;
        private readonly IAccountService accountService;

        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IForumService forumService,
            ICommentService commentService,
            IAccountService accountService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.forumService = forumService;
            this.commentService = commentService;
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> DisplayProfile()
        {
            var user = await userManager.GetUserAsync(User);

            var model = await accountService.GetUserDetailsAsync(user);

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

        [HttpGet]
        public async Task<IActionResult> LastActivity()
        {
            var user = await userManager.GetUserAsync(User);

            var comments = await commentService.GetUserCommentsAsync(user.Id);
            var posts = await forumService.GetUserPostsAsync(user.UserName);
            var model = await accountService.GetLastActivityAsync(comments, posts, user.Id);          

            return View(model);
        }
    }
}
