using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Reviews;
using News_Reviews.Services.Interfaces;
using System.Security.Claims;

namespace News_Reviews.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly IReviewsService service;

        public ReviewsController(IReviewsService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var reviews = await service.GetReviewsAsync();

            return View(reviews);
        }

        public async Task<IActionResult> AllPc()
        {
            var reviews = await service.GetReviewsAsync();

            return View(reviews.Where(r => r.Platform == "PC"));
        }

        public async Task<IActionResult> AllPlaystation()
        {
            var reviews = await service.GetReviewsAsync();

            return View(reviews.Where(r => r.Platform == "Playstation"));
        }

        public async Task<IActionResult> AllXbox()
        {
            var reviews = await service.GetReviewsAsync();

            return View(reviews.Where(r => r.Platform == "Xbox"));
        }

        public async Task<IActionResult> AllNintendo()
        {
            var reviews = await service.GetReviewsAsync();

            return View(reviews.Where(r => r.Platform == "Nintendo"));
        }

        public async Task<IActionResult> AllMobile()
        {
            var reviews = await service.GetReviewsAsync();

            return View(reviews.Where(r => r.Platform == "Mobile"));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var platforms = await service.GetPlatformAsync();

            var model = new ReviewFormModel
            {
                Platforms = platforms
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReviewFormModel model)
        {
            var validPlatforms = await service.GetPlatformAsync();

            if (!validPlatforms.Any(p => p.Id == model.PlatformId))
            {
                ModelState.AddModelError(nameof(model.PlatformId), "Invalid platform");
            }

            await service.AddNewReview(model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Read(int id)
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            var comments = service.GetCommendsAsync(id, username);

            ReadReviewModel review = await service.ReadReview(id, comments.Result);
            
            return View(review);
        }

        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await service.DeleteReview(id);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var review = await service.FindReviewById(id);

            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ReviewEditModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await service.EditReviewAsync(id, model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction($"{nameof(All)}");
        }

        public async Task<IActionResult> AddComment(CommentsFormModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await service.AddNewCommentAsync(model, userId);

            return RedirectToAction("All", "Reviews");
        }

        public async Task<IActionResult> RemoveComment(int id)
        {
            try
            {
                await service.DeleteReview(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
