using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
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

        public async Task<IEnumerable<NewsViewModel>> GetNewsAsync()
        {
            var models = await context.News.ToArrayAsync();

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
    }
}
