using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models;
using News_Reviews.Models.Models.News;
using News_Reviews.Services.Interfaces;

namespace News_Reviews.Services.Services
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext context;
        private IReviewsService reviewsService;

        public NewsService(ApplicationDbContext context, IReviewsService reviewsService)
        {
            this.context = context;
            this.reviewsService = reviewsService;
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

        public async Task DeleteNews(int id)
        {
            var news = await context.News
                .FirstOrDefaultAsync(n => n.Id == id);

            if(news != null)
            {
                context.News.Remove(news);
            }

            await context.SaveChangesAsync();
        }

        public async Task EditNewsAsync(int id, NewsFormModel model)
        {
            var news = await context.News
                .FirstOrDefaultAsync (n => n.Id == id);

            if(news != null)
            {
                news.Id = model.Id;
                news.Title = model.Title;
                news.Content = model.Content;
            }
            await context.SaveChangesAsync();
        }

        public async Task<NewsEditModel> FindNewsById(int id)
        {
            var news = await context.News
                .Include(r => r.Platform)
                .FirstOrDefaultAsync(r => r.Id == id);

            var newsContext = await context.News.ToArrayAsync();

            if (news != null)
            {
                NewsEditModel newsModel = new NewsEditModel()
                {
                    Id = news.Id,
                    Title = news.Title,
                    Content = news.Content,
                };

                return newsModel;
            }
            return null;
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
            var platforms = await reviewsService.GetPlatformAsync();

           // var models = await context.Platforms.ToArrayAsync();
           //
           // var platform = models
           //     .Select(p => new PlatformViewModel
           //     {
           //         Id = p.Id,
           //         Name = p.Name,
           //     });

            return platforms;
        }

        public async Task<ReadNewsModel> ReadNews(int id)
        {
            var news = await context.News
                .Where(n => n.Id == id)
                .Select(x => new ReadNewsModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                })
                .FirstOrDefaultAsync();

            return news;
        }
    }
}
