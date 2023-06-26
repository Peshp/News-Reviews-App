using Microsoft.AspNetCore.Mvc;

namespace News_Reviews.Controllers
{
    public class NewsReviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
