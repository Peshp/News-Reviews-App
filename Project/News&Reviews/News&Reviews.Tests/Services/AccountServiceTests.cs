using News_Reviews.Data;
using News_Reviews.DataModels.DataModels;
using News_Reviews.DataModels;
using News_Reviews.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using News_Reviews.Services.Services;
using X.PagedList;
using News_Reviews.Models.Models.Account;

namespace News_Reviews.Tests.Services
{
    public class AccountServiceTests
    {
        private ApplicationDbContext context;
        private IAccountService accountService;
        private IForumService forumService;
        private ICommentService commentService;

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
            SeedInMemoryData.SeedUsers(context);

            await context.AddRangeAsync(posts);
            await context.AddRangeAsync(reviews);
            await context.AddRangeAsync(comment);

            await context.SaveChangesAsync();

            commentService = new CommentService(context);
            forumService = new ForumService(context);
            accountService = new AccountService(context);
        }

        [Test]
        public async Task GetLastActivityAsync_ShouldWorkProperly()
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Id == "40d45d54-4e27-4c4c-b751-0fff188c021d");

            var comments = await commentService.GetUserCommentsAsync(user.Id);
            var posts = await forumService.GetUserPostsAsync(user.UserName);

            var result = accountService.GetLastActivityAsync
                (comments, posts, user.Id);

            var commentsCount = 0;
            var postsCount = 0;
            foreach (var item in result.Result)
            {
                commentsCount = item.Comments.Count();
                postsCount = item.Posts.Count();
            }


            Assert.That(commentsCount, Is.EqualTo(1));
            Assert.That(postsCount, Is.EqualTo(2));
        }

        [Test]
        public async Task GetUserDetailsAsync_ShouldWorkProperly()
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Id == "40d45d54-4e27-4c4c-b751-0fff188c021d");

            var result = await accountService.GetUserDetailsAsync(user);

            Assert.That(result.UserId, Is.EqualTo(user.Id));
            Assert.That(result.Username, Is.EqualTo(user.UserName));
            Assert.That(result.Password, Is.EqualTo(user.PasswordHash));
        }
    }
}
