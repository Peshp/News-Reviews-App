using News_Reviews.DataModels;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models.Forum;
using News_Reviews.Models.Models.News;
using News_Reviews.Models.Models.Reviews;
using News_Reviews.Services.Interfaces;
using System;

namespace News_Reviews.Services.Services
{
    public class SearchService : ISearchService
    {
        public async Task<IEnumerable<NewsViewModel>> SearchNews(string query, IEnumerable<NewsViewModel> news)
        {
            if(query != null)
            {
                news = news.Where(n => n.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
            }

            return news;
        }

        public async Task<IEnumerable<PostViewModel>> SearchPosts(string query, IEnumerable<PostViewModel> posts)
        {
            if (query != null)
            {
                posts = posts.Where(r => r.Content.Contains(query, StringComparison.OrdinalIgnoreCase));
            }

            return posts;
        }

        public async Task<IEnumerable<ReviewsViewModel>> SearchReview(string query, IEnumerable<ReviewsViewModel> reviews)
        {
            if (query != null)
            {
                reviews = reviews.Where(r => r.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
            }
            
            return reviews;
        }

        public async Task<IEnumerable<ThemesViewModel>> SearchThemes(string query, IEnumerable<ThemesViewModel> themes)
        {
            if (query != null)
            {
                themes = themes.Where(r => r.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
            }

            return themes;
        }
    }
}
