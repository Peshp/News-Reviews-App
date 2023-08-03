using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;
using System;

namespace News_Reviews.Tests.Services
{
    [TestFixture]
    public class QuizServiceTests
    {
        private ApplicationDbContext context;
        private IQuizService quizService;

        [SetUp]
        public async Task Setup()
        {
            var questions = new List<Question>()
            {
                new Question()
                {
                    Id = 1,
                    Title = "Test",
                },

                new Question()
                {
                    Id = 2,
                    Title = "Tes",
                }
            };

            var asnwets = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    Title= "Test",
                    Points = 1,
                    QuestionId = 1,
                },

                new Answer()
                {
                    Id = 2,
                    Title= "Tes2",
                    Points = 2,
                    QuestionId = 2,
                },

                new Answer()
                {
                    Id = 3,
                    Title= "Test3",
                    Points = 2,
                    QuestionId = 1,
                },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "NewsReviews")
               .Options;
            context = new ApplicationDbContext(options);

            await context.Database.EnsureDeletedAsync();
            await context.AddRangeAsync(questions);
            await context.AddRangeAsync(asnwets);
            await context.SaveChangesAsync();

            quizService = new QuizService(context);
        }

        [Test]
        public async Task GetQuestions_ShouldWorkProperly()
        {
            var questions = await quizService.GetQuestions();

            var question1 = questions.FirstOrDefault(q => q.Id == 1);
            var question2 = questions.FirstOrDefault(q => q.Id == 2);

            Assert.That(questions.Count, Is.EqualTo(2));
            Assert.That(question1.Answers.Count, Is.EqualTo(2));
            Assert.That(question2.Answers.Count, Is.EqualTo(1));
        }
    }
}
