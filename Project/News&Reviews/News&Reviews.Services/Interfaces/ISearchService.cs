using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models.Forum;
using News_Reviews.Models.Models.News;
using News_Reviews.Models.Models.Reviews;
using System.IO;

namespace News_Reviews.Services.Interfaces
{
    public interface ISearchService
    {
        Task<IEnumerable<ReviewsViewModel>> SearchReview(string query, IEnumerable<ReviewsViewModel> reviews);

        Task<IEnumerable<NewsViewModel>> SearchNews(string query, IEnumerable<NewsViewModel> news);

        Task<IEnumerable<PostViewModel>> SearchPosts(string query, IEnumerable<PostViewModel> posts);

        Task<IEnumerable<ThemesViewModel>> SearchThemes(string query, IEnumerable<ThemesViewModel> themes);
    }
}
