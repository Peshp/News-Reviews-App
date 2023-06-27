using Microsoft.AspNetCore.Mvc;
using News_Reviews.Models.Models;
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
    }
}
