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
        private readonly IReviewsService reviewsService;
        private readonly INewsService newsService;

        public HomeController(ILogger<HomeController> logger,
            IReviewsService reviewsService,
            INewsService newsService)
        {
            _logger = logger;
            this.reviewsService = reviewsService;
            this.newsService = newsService;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<ReviewsViewModel> reviews = await reviewsService.GetReviewsAsync();
            IEnumerable<NewsViewModel> news = await newsService.GetNewsAsync();
            
            ViewBag.Reviews = reviews.Take(6); 
            ViewBag.News = news.OrderBy(d => d.Data).Take(8);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}