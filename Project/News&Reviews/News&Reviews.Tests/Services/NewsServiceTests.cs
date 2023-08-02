using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models.News;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;
using System;

namespace News_Reviews.Tests.Services
{
    [TestFixture]
    public class NewsServiceTests
    {
        private ApplicationDbContext context;
        private INewsService newsService;
        private IReviewsService reviewsService;

        [SetUp]
        public async Task Setup()
        {
            var news = new List<News>()
            {
                new News
                {
                    Title = "Test",
                    Content = "Newstest",
                    Data = DateTime.Now,
                    PlatformId = 1,
                },

                new News
                {
                    Title = "Tes2",
                    Content = "Newstest2",
                    Data = DateTime.Now,
                    PlatformId = 2,
                }
            };

            var platforms = new List<Platform>()
            {
                new Platform
                {
                    Id = 1,
                    Name = "Test",
                },
                new Platform
                {
                    Id = 2,
                    Name = "Test2",
                },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "NewsReviews")
               .Options;
            context = new ApplicationDbContext(options);

            await context.Database.EnsureDeletedAsync();
            await context.AddRangeAsync(news);
            await context.AddRangeAsync(platforms);

            await context.SaveChangesAsync();

            reviewsService = new ReviewsService(context);
            newsService = new NewsService(context, reviewsService);
        }

        [Test]
        public async Task GetNews_ReturnCorrectNews()
        {
            var news = await newsService.GetNewsAsync();

            Assert.That(news.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task FindNewsById_ReturnCorrectNews()
        {
            var result = await newsService.FindNewsById(2);
            var result2 = await newsService.FindNewsById(3);

            Assert.That(result.Title, Is.EqualTo("Tes2"));
            Assert.IsNull(result2);
        }

        [Test]
        public async Task AddNews_ShouldWorkProperly()
        {
            var newsToAdd = new NewsFormModel
            {
                Id = 3,
                Title = "Test",
                Content = "Newstest",
                PlatformId = 2,
            };

            await newsService.AddNews(newsToAdd);
            var result = await newsService.FindNewsById(3);

            Assert.That(context.News.Count, Is.EqualTo(3));
            Assert.That(result.Data.ToString(), Is.EqualTo(DateTime.Now.ToString()));
        }

        [Test]
        public async Task DeleteNews_ShouldWorkProperly()
        {
            await newsService.DeleteNews(2);
            var result = await newsService.FindNewsById(2);

            Assert.That(context.News.Count, Is.EqualTo(1));
            Assert.IsNull(result);
        }

        [Test]
        public async Task EditNews_ShouldWorkProperly()
        {
            var newsToEdit = new NewsFormModel
            {
                Id = 2,
                Title = "Test2",
                Content = "Newstest",
                PlatformId = 2,
            };
            await newsService.EditNewsAsync(2, newsToEdit);

            var news = await newsService.FindNewsById(2);

            Assert.That(news.Title, Is.EqualTo("Test2"));
            Assert.That(news.PlatformId, Is.EqualTo(2));
        }

        [Test]
        public async Task ReadNews_ShouldReturnCorrectNews()
        {
            var expected = await newsService.FindNewsById(1);
            var result = await newsService.ReadNews(1);
            var result2 = await newsService.ReadNews(5);

            Assert.That(expected.Title, Is.EqualTo(result.Title));
            Assert.That(expected.Content, Is.EqualTo(result.Content));
            Assert.IsNull(result2);
        }
    }
}
