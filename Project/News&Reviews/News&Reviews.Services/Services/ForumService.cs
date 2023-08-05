using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Forum;
using News_Reviews.Services.Interfaces;
using System.Net;

namespace News_Reviews.Services.Services
{
    public class ForumService : IForumService
    {
        private readonly ApplicationDbContext context;

        public ForumService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddNewPostAsync(PostViewModel model, string userId, int themeId)
        {
            var usser = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            Post post = new Post()
            {
                Content = WebUtility.HtmlEncode(model.Content),
                ThemeId = model.ThemeId,
                Username = usser.UserName,
                ApplicationUserId = userId,
            };

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task AddNewThemeAsync(ThemesFormModel model)
        {
            Theme theme = new Theme()
            {
                Id = model.Id,
                Title = WebUtility.HtmlEncode(model.Title),
            };

            await context.AddAsync(theme);
            await context.SaveChangesAsync();
        }

        public async Task EditPostAsync(PostFormModel model, int id, string userid)
        {
            var post = await context
                .Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (post != null) 
            {
                post.Id = id;
                post.Content = model.Content;
                post.ThemeId = model.ThemeId;
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetPostsAsync(int themeId)
        {
            var models = await context.Posts
                .Where(p => p.ThemeId == themeId)
                .ToArrayAsync();

            var posts = models
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Content = p.Content,
                    Username = p.Username,
                    ThemeId = themeId,
                });

            return posts;
        }

        public async Task<IEnumerable<ThemesViewModel>> GetThemesAsync(IEnumerable<PostViewModel> posts)
        {
            var models = await context.Themes
                .ToListAsync();

            var themes = models
                .Select(x => new ThemesViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Posts = posts.ToList(),
                });

            return themes;
        }

        public async Task<IEnumerable<PostViewModel>> GetUserPostsAsync(string userName)
        {
            var models = await context.Posts
                .Where(p => p.Username == userName)
                .ToArrayAsync();

            var posts = models
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Content = p.Content,
                    Username = p.Username,
                });

            return posts;
        }

        public async Task RemovePostAsync(int postId)
        {
            var post = await context.Posts
                .FirstOrDefaultAsync(x => x.Id == postId);

            if(post != null)
            {
                context.Remove(post);
            }

            await context.SaveChangesAsync();
        }

        public async Task RemoveThemeAsync(int themeId)
        {
            var theme = await context.Themes
                .FirstOrDefaultAsync(x => x.Id == themeId);

            context.Themes.Remove(theme);
            await context.SaveChangesAsync();
        }
    }
}
