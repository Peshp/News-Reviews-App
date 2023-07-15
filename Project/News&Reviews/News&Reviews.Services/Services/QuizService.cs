using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.Models.Models.Quzi;
using News_Reviews.Services.Interfaces;
using System.Xml.Linq;

namespace News_Reviews.Services.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext context;

        public QuizService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<QuestionsViewModel>> GetQuestions()
        {
            var models = await context.Questions
                .Include(q => q.Answers)
                .ToArrayAsync();

            var questions = models
                .Select(q => new QuestionsViewModel
                {
                    Id = q.Id,
                    Title = q.Title,
                    Answers = q.Answers.Select(a => new AnswersViewModel
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Points = a.Points,
                        QuestionId = q.Id,
                    })
                    .ToArray(),
                }); 

            return questions;
        }
    }
}
