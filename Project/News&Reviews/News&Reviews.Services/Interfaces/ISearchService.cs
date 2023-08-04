using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models.News;
using News_Reviews.Models.Models.Reviews;
using System.IO;

namespace News_Reviews.Services.Interfaces
{
    public interface ISearchService
    {
        Task<IEnumerable<ReviewsViewModel>> SearchReview(string query, IEnumerable<ReviewsViewModel> reviews);

        Task<IEnumerable<NewsViewModel>> SearchNews(string query, IEnumerable<NewsViewModel> news);
    }
}
