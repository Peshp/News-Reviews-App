using Microsoft.AspNetCore.Mvc;
using News_Reviews.Models.Models.News;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;

namespace News_Reviews.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService service;

        public NewsController(INewsService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var news = await service.GetNewsAsync();

            return View(news);
        }

        public async Task<IActionResult> AllPc()
        {
            var news = await service.GetNewsAsync();

            return View(news.Where(n => n.Platform == "PC"));
        }

        public async Task<IActionResult> AllPlaystation()
        {
            var news = await service.GetNewsAsync();

            return View(news.Where(n => n.Platform == "Playstation"));
        }

        public async Task<IActionResult> AllXbox()
        {
            var news = await service.GetNewsAsync();

            return View(news.Where(n => n.Platform == "Xbox"));
        }

        public async Task<IActionResult> AllNintendo()
        {
            var news = await service.GetNewsAsync();

            return View(news.Where(n => n.Platform == "Nintendo"));
        }

        public async Task<IActionResult> AllMobile()
        {
            var news = await service.GetNewsAsync();

            return View(news.Where(n => n.Platform == "Mobile"));
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
