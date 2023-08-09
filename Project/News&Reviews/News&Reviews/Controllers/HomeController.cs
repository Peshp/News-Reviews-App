using Microsoft.AspNetCore.Mvc;
using News_Reviews.Models;
using News_Reviews.Models.Models;
using News_Reviews.Models.Models.News;
using News_Reviews.Models.Models.Reviews;
using News_Reviews.Services.Interfaces;
using System.Diagnostics;

namespace News_Reviews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IReviewsService reviewsService;
        private INewsService newsService;
        private IForumService forumService;

        public HomeController(ILogger<HomeController> logger, 
            IReviewsService reviewsService, 
            INewsService newsService, 
            IForumService forumService)
        {
            _logger = logger;
            this.reviewsService = reviewsService;
            this.newsService = newsService;
            this.forumService = forumService;
        }


        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole("Admin"))
            {
                return this.RedirectToAction("Index", "Home", new { Area = "Administration" });
            }

            var model = new HomeModel
            {
                Reviews = await reviewsService.GetReviewsAsync(),
                News = await newsService.GetNewsAsync(),
                Posts = await forumService.GetPostsAsync(2),
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}