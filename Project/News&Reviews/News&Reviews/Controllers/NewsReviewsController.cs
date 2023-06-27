using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.Services.Interfaces;

namespace News_Reviews.Controllers
{
    [Authorize]
    public class NewsReviewsController : Controller
    {
        private readonly INewsReviewsInterface service;

        public NewsReviewsController(string platform)
        {
            Platform = platform;
        }

        public string Platform { get; set; }

        public NewsReviewsController(INewsReviewsInterface service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var reviews = await service.GetReviewsAsync();

            return View(reviews);
        }
    }
}
