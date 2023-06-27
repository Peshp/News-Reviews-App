using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.Models.Models;
using News_Reviews.Services.Interfaces;

namespace News_Reviews.Services.Services
{
    public class NewsReviewsService : INewsReviewsInterface
    {
        private readonly ApplicationDbContext context;

        public async Task<IEnumerable<ReviewsViewModel>> GetReviewsAsync()
        {
            var models = await context.Reviews.Include(g => g.Game).ToArrayAsync();

            var reviews = models
                .Select(r => new ReviewsViewModel
                {
                    Id = r.Id,
                    Game = r.Game.Name,
                    Title = r.Title,
                    Content = r.Content,
                    ImageURL = r.ImageURL,
                });

            return reviews;
        }
    }
}
