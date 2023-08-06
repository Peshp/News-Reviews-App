using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
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
        private IForumService forumService;
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

            var themes = new List<Theme>()
            {
                new Theme()
                {
                    Id = 1,
                    Title = "Test",
                },

                new Theme()
                {
                    Id = 2,
                    Title = "Test2",
                },
            };

            var posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Content = "Test",
                    ThemeId = 1,
                    Username = "pesho",
                    ApplicationUserId = "40d45d54-4e27-4c4c-b751-0fff188c021d",
                },

                new Post()
                {
                    Id = 2,
                    Content = "Tes2",
                    ThemeId = 1,
                    Username = "pesho",
                    ApplicationUserId = "40d45d54-4e27-4c4c-b751-0fff188c021d",
                },
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
            forumService = new ForumService(context);
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
            var expected = reviews.Where(n => n.Title.Contains("of", StringComparison.OrdinalIgnoreCase));

            reviews = await searchService.SearchReview("of", reviews);           
            Assert.That(expected, Is.EqualTo(reviews));
        }

        [Test]
        public async Task SearchPosts_ShouldReturnCorrectPosts()
        {
            var posts = await forumService.GetPostsAsync(1);
            var expected = posts.Where(p => p.Content.Contains("test", StringComparison.OrdinalIgnoreCase));

            posts = await searchService.SearchPosts("test", posts);        
            Assert.That(expected, Is.EqualTo(posts));
        }

        [Test]
        public async Task SearchThemes_ShouldReturnCorrectThemes()
        {
            var posts = await forumService.GetPostsAsync(1);
            var themes = await forumService.GetThemesAsync(posts);
            var expected = themes.Where(t => t.Title.Contains("test", StringComparison.OrdinalIgnoreCase));

            themes = await searchService.SearchThemes("test", themes);
            Assert.That(expected, Is.EqualTo(themes));
        }
    }
}
