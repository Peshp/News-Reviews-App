using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> All(int id, int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;          

            var username = User.FindFirstValue(ClaimTypes.Name);

            var posts = await service.GetPostsAsync(id, username);
            var themes = await service.GetThemesAsync(posts);

            var onePageOfThemes = themes.ToPagedList(pageNumber, pageSize);

            return View(onePageOfThemes);
        }

        [HttpGet]
        public async Task<IActionResult> AddTheme()
        {
            return View();
        }

        [HttpPost]
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

        public async Task<IActionResult> RemoveTheme(int id)
        {
            try
            {
                await service.RemoveThemeAsync(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> AllPosts(int id, int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var username = User.FindFirstValue(ClaimTypes.Name);
            var posts = await service.GetPostsAsync(id, username);

            var onePageOfThemes = posts.ToPagedList(pageNumber, pageSize);

            return View(onePageOfThemes);
        }

        public async Task<IActionResult> AddPost(PostViewModel model, int themeId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await service.AddNewPostAsync(model, userId, themeId);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemovePost(int id)
        {
            try
            {
                await service.RemovePostAsync(id);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return RedirectToAction(nameof(AllPosts));
        }
    }
}
