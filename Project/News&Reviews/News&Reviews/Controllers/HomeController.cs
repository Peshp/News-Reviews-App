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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}