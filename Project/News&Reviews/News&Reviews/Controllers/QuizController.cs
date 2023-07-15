using Microsoft.AspNetCore.Mvc;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;

namespace News_Reviews.Controllers
{
    public class QuizController : Controller
    {
        private readonly IQuizService service;

        public QuizController(IQuizService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var questions = await service.GetQuestions();           

            return View(questions);
        }
    }
}
