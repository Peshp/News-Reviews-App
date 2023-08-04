using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;
using System;

namespace News_Reviews.Tests.Services
{
    [TestFixture]
    public class CommentServiceTests
    {
        private ApplicationDbContext context;
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

            await context.AddRangeAsync(reviews);
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

            commentsService = new CommentService(context);
        }

        [Test]
        public async Task AddNewComment_ShouldWorkProperly()
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Id == "40d45d54-4e27-4c4c-b751-0fff188c021d");

            var comment = new CommentsFormModel()
            {
                ReviewId = 1,
                Username = "pesho",
                Content = "blah blah blah",
            };
            await commentsService.AddNewCommentAsync(comment, user.Id);

            var review = await context.Reviews
                .Where(r => r.Id == 1)
                .FirstOrDefaultAsync();
            Assert.That(review.Comments.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetComments_ReturnCorrectResult()
        {
            var result = await commentsService.GetCommentsAsync(1);

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task RemoveComment_ShouldWorkProperly()
        {
            await commentsService.RemoveCommentAsync(1);

            var review = await context.Reviews
                .Where(r => r.Id == 1)
                .FirstOrDefaultAsync();
            Assert.That(review.Comments.Count, Is.EqualTo(0));

            Assert.That(context.Comments.Count(), Is.EqualTo(0));
        }
    }
}
