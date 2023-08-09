using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.News;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;

using X.PagedList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace News_Reviews.Controllers
{
    /// <summary>
    /// Used X.PagedList to create pagination
    /// </summary>

    [Authorize]
    public class NewsController : Controller
    {
        private readonly INewsService service;
        private readonly ISearchService searchService;

        public NewsController(INewsService service, ISearchService searchService)
        {
            this.service = service;
            this.searchService = searchService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 16;

            var news = await service.GetNewsAsync();
            news = await searchService.SearchNews(query, news);

            var onePageOfNews = news.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllPc(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var pcNews = news.Where(n => n.Platform == "PC");
            pcNews = await searchService.SearchNews(query, pcNews);

            var onePageOfNews = pcNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllPlaystation(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var psNews = news.Where(n => n.Platform == "Playstation");
            psNews = await searchService.SearchNews(query, psNews);

            var onePageOfNews = psNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllXbox(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var xboxNews = news.Where(n => n.Platform == "Xbox");
            xboxNews = await searchService.SearchNews(query, xboxNews);

            var onePageOfNews = xboxNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllNintendo(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var nintendoNews = news.Where(n => n.Platform == "Nintendo");
            nintendoNews = await searchService.SearchNews(query, nintendoNews);

            var onePageOfNews = nintendoNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllMobile(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var mobNews = news.Where(n => n.Platform == "Phone");
            mobNews = await searchService.SearchNews(query, mobNews);

            var onePageOfNews = mobNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }       

        [AllowAnonymous]
        public async Task<IActionResult> Read(int id)
        {

            ReadNewsModel news = await service.ReadNews(id);

            return View(news);             
        }

        public async Task<IActionResult> Remove(int id)
        {
            await service.DeleteNews(id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var news = await service.FindNewsById(id);

            var platforms = await service.GetPlatformAsync();
            news.Platforms = platforms;

            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewsFormModel model)
        {
            await service.EditNewsAsync(id, model);

            return RedirectToAction(nameof(All));
        }
    }
}
