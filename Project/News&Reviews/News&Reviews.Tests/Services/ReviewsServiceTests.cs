using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models.Reviews;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;
using System.Threading.Tasks;
using System;
using System.IO.Pipelines;
using News_Reviews.Models.Models.Comments;

namespace News_Reviews.Tests.Services
{
    [TestFixture]
    public class ReviewsServiceTests
    {
        private ApplicationDbContext context;
        private IReviewsService reviewsService;
        private ICommentService commentsService;

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

            var comment = new Comment()
            {
                Content = "blah blah blah",
                Username = "pesho",
                UserId = "40d45d54-4e27-4c4c-b751-0fff188c021d",
                ReviewId = 1,
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "NewsReviews")
               .Options;
            context = new ApplicationDbContext(options);

            await context.Database.EnsureDeletedAsync(); 
            SeedInMemoryData.SeedUsers(context);

            await context.Comments.AddAsync(comment);
            await context.AddRangeAsync(reviews);
            await context.AddRangeAsync(platforms);
            await context.AddRangeAsync(genres);
            await context.AddRangeAsync(publishers);
            await context.SaveChangesAsync();
            
            reviewsService = new ReviewsService(context);
            commentsService = new CommentService(context);
        }

        [Test]
        public async Task GetReviewsAsync_ReturnCorrectReviews()
        {
            var result = await reviewsService.GetReviewsAsync();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetPublishersAsync_ReturnCorrectResult()
        {
            var result = await reviewsService.GetPublishersAsync();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetGenresAsync_ReturnCorrectResult()
        {
            var result = await reviewsService.GetGenresAsync();

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetPlatformsAsync_ReturnCorrectResult()
        {
            var result = await reviewsService.GetPlatformAsync();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task FindReviewById_ReturnCorrectReview()
        {
            var result = await reviewsService.FindReviewById(1);
            var result2 = await reviewsService.FindReviewById(3);

            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.PlatformId, Is.EqualTo(1));
            Assert.That(result.GenreId, Is.EqualTo(1));
            Assert.That(result.PublisherId, Is.EqualTo(1));
            Assert.IsNull(result2);
        }

        [Test]
        public async Task AddNewReview_WorkProperly()
        {
            var review = new ReviewFormModel()
            {
                Id = 3,
                Title = "Title",
                Content = "Content",
                ImageURL = "Tast",
                PlatformId = 1,
                GenreId = 1,
                PublisherId = 1,
            };

            await reviewsService.AddNewReview(review);

            var result = await reviewsService.FindReviewById(3);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task DeleteReview_WorkProperly()
        {
            var review = new ReviewFormModel()
            {
                Id = 3,
                Title = "Title",
                Content = "Content",
                ImageURL = "Tast",
                PlatformId = 1,
                GenreId = 1,
                PublisherId = 1,
            };

            await reviewsService.AddNewReview(review);
            await reviewsService.DeleteReview(3);

            var result = await reviewsService.FindReviewById(3);

            Assert.IsNull(result);
        }

        [Test]
        public async Task EditReviewAsync_WorkProperly()
        {
            var reviewToChange = await reviewsService.FindReviewById(1);
            Assert.That(reviewToChange.PublisherId, Is.EqualTo(1));

            reviewToChange = new ReviewFormModel()
            {
                Id = 1,
                Title = "Grand Theft Auto V",
                Content = "Grand Theft Auto x10",
                ImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202202/2816/mYn2ETBKFct26V9mJnZi4aSS.png",
                PlatformId = 1,
                GenreId = 1,
                PublisherId = 2,
            };                    

            await reviewsService.EditReviewAsync(1, reviewToChange);
            Assert.That(reviewToChange.PublisherId, Is.EqualTo(2));
        }

        

        [Test]
        public async Task ReadReview_ReturnCorrectReviewWithComment()
        {
            var comments = await commentsService.GetCommentsAsync(1);
            var result = await reviewsService.ReadReview(1, comments);

            Assert.That(result.Title, Is.EqualTo("Grand Theft Auto V"));
            Assert.That(result.Comments.Count, Is.EqualTo(1));
        }
    }
}
