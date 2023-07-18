using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.News;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;

using X.PagedList;

namespace News_Reviews.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly INewsService service;

        public NewsController(INewsService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();

            var onePageOfNews = news.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllPc(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var pcNews = news.Where(n => n.Platform == "PC");

            var onePageOfNews = pcNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllPlaystation(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var psNews = news.Where(n => n.Platform == "Playstation");

            var onePageOfNews = psNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllXbox(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var xboxNews = news.Where(n => n.Platform == "Xbox");

            var onePageOfNews = xboxNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllNintendo(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var nintendoNews = news.Where(n => n.Platform == "Nintendo");

            var onePageOfNews = nintendoNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllMobile(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var news = await service.GetNewsAsync();
            var mobNews = news.Where(n => n.Platform == "Mobile");

            var onePageOfNews = mobNews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfNews);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var platforms = await service.GetPlatformAsync();

            var model = new NewsFormModel()
            {
                Platforms = platforms,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewsFormModel model)
        {
            var validPlatforms = await service.GetPlatformAsync();

            if (!validPlatforms.Any(p => p.Id == model.PlatformId))
            {
                ModelState.AddModelError(nameof(model.PlatformId), "Invalid platform");
            }

            if (ModelState.IsValid)
            {
                model.Platforms = validPlatforms;
                return View(model);
            }

            await service.AddNews(model);

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Read(int id)
        {

            ReadNewsModel news = await service.ReadNews(id);

            return View(news);             
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await service.DeleteNews(id);
            }
            catch (Exception)
            {
                return BadRequest();              
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var news = await service.FindNewsById(id);

            if(news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewsFormModel model)
        {
            if(ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await service.EditNewsAsync(id, model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction(nameof(All));
        }
    }
}
