using News_Reviews.Models.Models;
using News_Reviews.Models.Models.News;

namespace News_Reviews.Services.Interfaces
{
    public interface INewsService
    {
        public Task<IEnumerable<NewsViewModel>> GetNewsAsync();

        public Task AddNews(NewsFormModel model);

        public Task<IEnumerable<PlatformViewModel>> GetPlatformAsync();

        public Task<ReadNewsModel> ReadNews(int id);

        public Task DeleteNews(int id);

        public Task<NewsEditModel> FindNewsById(int id);

        public Task EditNewsAsync(int id, NewsFormModel model);
    }
}
