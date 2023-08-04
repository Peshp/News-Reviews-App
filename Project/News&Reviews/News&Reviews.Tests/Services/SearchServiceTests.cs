using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;

namespace News_Reviews.Tests.Services
{
    public class SearchServiceTests
    {
        private ISearchService searchService;
        private IReviewsService reviewsService;
        private INewsService newsService;
        private ApplicationDbContext context;

        [SetUp]
        public async Task Setup()
        {
            var reviews = new List<Review>()
            {
                new Review
                {
                    Id = 1,
                    Title = "Grand Theft Auto V",
                    Content = "Grand Theft Auto x10",
                    ImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202202/2816/mYn2ETBKFct26V9mJnZi4aSS.png",
                    PlatformId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                },

                new Review
                {
                    Id = 2,
                    Title = "Grand Theft Auto IV",
                    Content = "Grand Theft Auto x8",
                    ImageURL = "https://upload.wikimedia.org/wikipedia/en/c/c4/GTASABOX.jpg",
                    PlatformId = 2,
                    GenreId = 1,
                    PublisherId = 2,
                }
            };

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

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "NewsReviews")
              .Options;
            context = new ApplicationDbContext(options);

            await context.Database.EnsureDeletedAsync();
            await context.AddRangeAsync(reviews);
            await context.AddRangeAsync(news);
            await context.SaveChangesAsync();

            reviewsService = new ReviewsService(context);
            newsService = new NewsService(context, reviewsService);
            searchService = new SearchService();
        }

        [Test]
        public async Task SearchNews_ShouldReturnCorrectNews()
        {
            var news = await newsService.GetNewsAsync();
            news = await searchService.SearchNews("amn", news);

            var expected = news.Where(n => n.Title.Contains("amn", StringComparison.OrdinalIgnoreCase));
            Assert.That(expected, Is.EqualTo(news));
        }

        [Test]
        public async Task SearchReview_ShouldReturnCorrectReviews()
        {
            var reviews = await reviewsService.GetReviewsAsync();
            reviews = await searchService.SearchReview("of", reviews);

            var expected = reviews.Where(n => n.Title.Contains("of", StringComparison.OrdinalIgnoreCase));
            Assert.That(expected, Is.EqualTo(reviews));
        }
    }
}
