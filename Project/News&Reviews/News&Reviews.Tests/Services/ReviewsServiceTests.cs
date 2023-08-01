using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;
using System;

namespace News_Reviews.Tests.Services
{
    [TestFixture]
    public class ReviewsServiceTests
    {
        private ApplicationDbContext context;
        private IReviewsService reviewsService;

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

            var genres = new List<Genre>()
            {
                new Genre
                {
                    Id = 1,
                    Name = "Test",
                }
            };

            var publishers = new List<Publisher>()
            {
                new Publisher
                {
                    Id = 1,
                    Name = "Test",
                },
                new Publisher
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
            await context.AddRangeAsync(reviews);
            await context.AddRangeAsync(platforms);
            await context.AddRangeAsync(genres);
            await context.AddRangeAsync(publishers);
            await context.SaveChangesAsync();

            reviewsService = new ReviewsService(context);
        }

        [Test]
        public async Task GetReviewsAsync_ReturnCorrectReviews()
        {
            var result = await reviewsService.GetReviewsAsync();

            Assert.That(result.Count, Is.EqualTo(2));
        }
    }
}
