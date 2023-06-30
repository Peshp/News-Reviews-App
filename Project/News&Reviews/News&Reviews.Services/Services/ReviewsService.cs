using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models;
using News_Reviews.Services.Interfaces;

namespace News_Reviews.Services.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly ApplicationDbContext context;

        public ReviewsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddNewReview(ReviewFormModel model)
        {
            Review review = new Review()
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                ImageURL = model.ImageURL,
                PlatformId = model.PlatformId,
            };

            context.Reviews.Add(review);
            await context.SaveChangesAsync();
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

        public async Task<IEnumerable<ReviewsViewModel>> GetReviewsAsync()
        {
            var models = await context.Reviews
                .Include(r => r.Platform)
                .ToArrayAsync();

            var reviews = models
                .Select(r => new ReviewsViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Content = r.Content,
                    ImageURL = r.ImageURL,
                    Platform = r.Platform.Name,
                });

            return reviews;
        }

        public async Task<ReadReviewModel> ReadReview(int Id)
        {
            var review = await context.Reviews
                .Where(r => r.Id == Id)
                .Select(r => new ReadReviewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Content = r.Content,
                })
                .FirstOrDefaultAsync();

            

            return review;
        }
    }
}
