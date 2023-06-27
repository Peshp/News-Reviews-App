using News_Reviews.Models.Models;

namespace News_Reviews.Services.Interfaces
{
    public interface INewsService
    {
        public Task<IEnumerable<NewsViewModel>> GetNewsAsync();
    }
}
