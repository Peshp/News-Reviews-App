using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.Models.Models.Reviews;
using News_Reviews.Services.Interfaces;
using System.Data;

namespace News_Reviews.Areas.Administration.Controllers
{
    public class ReviewController : BaseAdminController
    {
        private IReviewsService service;

        public ReviewController(IReviewsService reviewsService)
        {
            service = reviewsService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var platforms = await service.GetPlatformAsync();
            var genres = await service.GetGenresAsync();
            var publishers = await service.GetPublishersAsync();

            var model = new ReviewFormModel
            {
                Platforms = platforms,
                Genres = genres,
                Publishers = publishers
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewFormModel model)
        {
            var validPlatforms = await service.GetPlatformAsync();

            await service.AddNewReview(model);

            return RedirectToAction("All", "Reviews", new { Area = "" });
        }
    }
}
