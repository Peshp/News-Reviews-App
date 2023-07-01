using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models;
using News_Reviews.Services.Interfaces;

namespace News_Reviews.Services.Services
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext context;

        public NewsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddNews(NewsFormModel model)
        {
            News news = new News()
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                Data = DateTime.Now,
                PlatformId = model.PlatformId
            };

            context.News.Add(news);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsViewModel>> GetNewsAsync()
        {
            var models = await context.News
                .Include(n => n.Platform)
                .ToArrayAsync();

            var news = models
                .Select(x => new NewsViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    Data = x.Data.ToString(),
                    Platform = x.Platform.Name,
                });

            return news;
        }

        public async Task<IEnumerable<PlatformViewModel>> GetPlatformAsync()
        {
            var models = await context.Platforms.ToArrayAsync();

            var platform = models
                .Select(p => new PlatformViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                });

            return platform;
        }
    }
}
