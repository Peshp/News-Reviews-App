using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Forum;
using News_Reviews.Services.Interfaces;
using System.Security.Claims;
using X.PagedList;

namespace News_Reviews.Controllers
{
    [Authorize]
    public class ForumController : Controller
    {
        private readonly IForumService service;

        public ForumController(IForumService _service)
        {
            service = _service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int id, int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;          

            var username = User.FindFirstValue(ClaimTypes.Name);
            var posts = await service.GetPostsAsync(id);

            var themes = await service.GetThemesAsync(posts);
            var onePageOfThemes = themes.ToPagedList(pageNumber, pageSize);

            return View(onePageOfThemes);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTheme()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTheme(ThemesFormModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["TitleError"] = "Title must be between 3 and 100 characters long.";
                return View(model);
            }

            await service.AddNewThemeAsync(model);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> RemoveTheme(int id)
        {
            await service.RemoveThemeAsync(id);

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllPosts(int id, int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var posts = await service.GetPostsAsync(id);

            var onePageOfThemes = posts.ToPagedList(pageNumber, pageSize);

            return View(onePageOfThemes);
        }

        [Authorize]
        public async Task<IActionResult> AddPost(PostViewModel model, int themeId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await service.AddNewPostAsync(model, userId, themeId);

            return RedirectToAction("AllPosts", new { id = themeId });
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> RemovePost(int id, int themeId)
        {
            await service.RemovePostAsync(id);

            return RedirectToAction("AllPosts", new { id = themeId });
        }
    }
}
