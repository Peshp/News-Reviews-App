using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Forum;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;
using System;

namespace News_Reviews.Tests.Services
{
    [TestFixture]
    public class ForumServiceTests
    {
        private ApplicationDbContext context;
        private IForumService forumService;

        [SetUp]
        public async Task Setup()
        {
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
            SeedInMemoryData.SeedUsers(context);

            await context.AddRangeAsync(themes);
            await context.AddRangeAsync(posts);
            await context.SaveChangesAsync();

            forumService = new ForumService(context);
        }

        [Test]
        public async Task AddNewPost_ShouldWorkProperly()
        {
            var post = new PostViewModel()
            {
                Id = 3,
                Content = "Test3",
                Username = "pesho",
                ThemeId = 1,
                UserId = "40d45d54-4e27-4c4c-b751-0fff188c021d",
            };

            await forumService.AddNewPostAsync(post, "40d45d54-4e27-4c4c-b751-0fff188c021d", 1);

            Assert.That(context.Posts.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task AddNewTheme_ShouldWorkProperly()
        {
            var theme = new ThemesFormModel()
            {
                Id = 3,
                Title = "Title",
            };

            await forumService.AddNewThemeAsync(theme);

            Assert.That(context.Themes.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task EditPostAsync_ShouldWorkProperly()
        {
            var post = new PostFormModel()
            {
                Content = "Test2",
                ThemeId = 1,
            };

            await forumService.EditPostAsync(post, 2, "40d45d54-4e27-4c4c-b751-0fff188c021d");
            var post2 = await context.Posts
                .FirstOrDefaultAsync(p => p.Id == 2);

            Assert.That(post2.Content, Is.EqualTo("Test2"));
        }

        [Test]
        public async Task GetPosts_ReturnCorrectPosts()
        {
            var posts = await forumService.GetPostsAsync(1);
            var posts2 = await forumService.GetPostsAsync(2);

            Assert.That(posts.Count, Is.EqualTo(2));
            Assert.That(posts2.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetThemes_ReturnCorrectThemes()
        {
            var posts = await forumService.GetPostsAsync(1);
            var themes = await forumService.GetThemesAsync(posts);

            Assert.That(themes.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task RemovePost_ShouldWorkProperly()
        {
            await forumService.RemovePostAsync(1);
            var theme = await context.Themes
                .FirstOrDefaultAsync(t => t.Id == 1);

            Assert.That(context.Posts.Count, Is.EqualTo(1));
            Assert.That(theme.Posts.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task RemoveTheme_ShouldWorkProperly()
        {
            await forumService.RemoveThemeAsync(1);

            Assert.That(context.Themes.Count, Is.EqualTo(1));
        }
    }
}
