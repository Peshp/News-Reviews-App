using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.Models.Models.News;
using News_Reviews.Services.Interfaces;
using System.Data;

namespace News_Reviews.Areas.Administration.Controllers
{
    public class NewsController : BaseAdminController
    {
        private INewsService service;

        public NewsController(INewsService newsService)
        {
            service = newsService;
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

            if (ModelState.IsValid)
            {
                model.Platforms = validPlatforms;
                return View(model);
            }

            await service.AddNews(model);

            return RedirectToAction("All", "News", new { Area = "" });
        }
    }
}
