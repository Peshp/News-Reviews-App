using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using News_Reviews.DataModels;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Reviews;
using News_Reviews.Services.Interfaces;
using System.Security.Claims;

using X.PagedList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace News_Reviews.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly IReviewsService service;
        private readonly ISearchService searchService;

        public ReviewsController(IReviewsService service, ISearchService searchService)
        {
            this.service = service;
            this.searchService = searchService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 12;

            var reviews = await service.GetReviewsAsync();
            reviews = await searchService.SearchReview(query, reviews);

            var onePageOfReviews = await reviews.ToPagedListAsync(pageNumber, pageSize);
            return View(onePageOfReviews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllPc(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var reviews = await service.GetReviewsAsync();
            var pcReviews = reviews.Where(r => r.Platform == "PC");
            pcReviews = await searchService.SearchReview(query, pcReviews);

            var onePageOfReviews = pcReviews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfReviews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllPlaystation(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var reviews = await service.GetReviewsAsync();
            var psReviews = reviews.Where(r => r.Platform == "Playstation");
            psReviews =  await searchService.SearchReview(query, psReviews);

            var onePageOfReviews = psReviews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfReviews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllXbox(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var reviews = await service.GetReviewsAsync();
            var xboxReviews = reviews.Where(r => r.Platform == "Xbox");
            xboxReviews = await searchService.SearchReview(query, xboxReviews);

            var onePageOfReviews = xboxReviews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfReviews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllNintendo(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var reviews = await service.GetReviewsAsync();
            var nintendoxReviews = reviews.Where(r => r.Platform == "Nintendo");
            nintendoxReviews = await searchService.SearchReview(query, nintendoxReviews);

            var onePageOfReviews = nintendoxReviews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfReviews);
        }

        [AllowAnonymous]
        public async Task<IActionResult> AllMobile(int? page, string query)
        {
            var pageNumber = page ?? 1;
            int pageSize = 8;

            var reviews = await service.GetReviewsAsync();
            var mobReviews = reviews.Where(r => r.Platform == "Phone");
            mobReviews = await searchService.SearchReview(query, mobReviews);

            var onePageOfReviews = mobReviews.ToPagedList(pageNumber, pageSize);

            return View(onePageOfReviews);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(ReviewFormModel model)
        {
            var validPlatforms = await service.GetPlatformAsync();

            await service.AddNewReview(model);

            return RedirectToAction(nameof(All));
        }


        [AllowAnonymous]
        public async Task<IActionResult> Read(int id)
        {            
            var comments = service.GetCommendsAsync(id);

            ReadReviewModel review = await service.ReadReview(id, comments.Result);
            
            return View(review);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Remove(int id)
        {
            await service.DeleteReview(id);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var review = await service.FindReviewById(id);

            var platforms = await service.GetPlatformAsync();
            var genres = await service.GetGenresAsync();
            var publishers = await service.GetPublishersAsync();

            review.Platforms = platforms;
            review.Genres = genres;
            review.Publishers = publishers;

            return View(review);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ReviewFormModel model)
        {
            var validPlatforms = await service.GetPlatformAsync();

            await service.EditReviewAsync(id, model);

            return RedirectToAction($"{nameof(All)}");
        }
        
        public async Task<IActionResult> AddComment(CommentsFormModel model, int themeId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await service.AddNewCommentAsync(model, userId);

            return RedirectToAction("Read", new { id = themeId });
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> RemoveComment(int id, int themeId)
        {
            await service.RemoveCommentAsync(id);

            return RedirectToAction("Read", new { id = themeId });
        }
    }
}
