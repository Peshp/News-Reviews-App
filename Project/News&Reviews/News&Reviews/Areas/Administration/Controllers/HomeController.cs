using Microsoft.AspNetCore.Mvc;

namespace News_Reviews.Areas.Administration.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
