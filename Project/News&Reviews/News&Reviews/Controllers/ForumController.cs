﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Forum;
using News_Reviews.Services.Interfaces;
using System.Security.Claims;
using X.PagedList;

namespace News_Reviews.Controllers
{
    /// <summary>
    /// Used X.PagedList to create pagination
    /// </summary>

    [Authorize]
    public class ForumController : Controller
    {
        private readonly IForumService service;
        private readonly ISearchService searchService;

        public ForumController(IForumService _service,
            ISearchService searchService)
        {
            service = _service;
            this.searchService = searchService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int id, int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;          

            var username = User.FindFirstValue(ClaimTypes.Name);
            var posts = await service.GetPostsAsync(id);

            var themes = await service.GetThemesAsync(posts);
            themes = await searchService.SearchThemes(query, themes);
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

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> RemoveTheme(int id)
        {
            await service.RemoveThemeAsync(id);

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllPosts(int id, int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var posts = await service.GetPostsAsync(id);
            posts = await searchService.SearchPosts(query, posts);

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
