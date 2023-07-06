using Microsoft.EntityFrameworkCore;
using News_Reviews.Common.UserConstants;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.DataModels.DataModels;
using News_Reviews.Models.Models;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Reviews;
using News_Reviews.Services.Interfaces;
using System.Net;
using System.Security.Claims;

namespace News_Reviews.Services.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly ApplicationDbContext context;

        public ReviewsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddNewCommentAsync(CommentsFormModel model, string userId, int id)
        {
            Comment comment = new Comment()
            {
                //Id = model.Id,
                ReviewId = model.ReviewId,  
                Content = model.Content,
                UserId = userId,
            };

            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
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

        public async Task DeleteReview(int id)
        {
            var review = await context.Comments
                .FirstOrDefaultAsync(r => r.Id == id);

            if (review != null)
            {
                context.Comments.Remove(review);
            }

            await context.SaveChangesAsync();
        }

        public async Task EditReviewAsync(int id, ReviewEditModel model)
        {
            var review = await context.Reviews
                .FirstOrDefaultAsync (r => r.Id == id);

            if (review != null)
            {
                review.Id = model.Id;
                review.Title = model.Title;
                review.Content = model.Content;
                review.ImageURL = model.ImageURL;
            }

            await context.SaveChangesAsync();
        }

        public async Task<ReviewEditModel> FindReviewById(int id)
        {
            var review = await context.Reviews
                .Include(r => r.Platform)
                .FirstOrDefaultAsync(r => r.Id == id);

            var reviews = await context.Reviews.ToArrayAsync();

            if (review != null)
            {
                ReviewEditModel reviewModel = new ReviewEditModel()
                {
                    Id = review.Id,
                    Title = review.Title,
                    Content = review.Content,
                    ImageURL = review.ImageURL,
                };

                return reviewModel;
            }
            return null;
        }

        public async Task<IEnumerable<CommentsViewModel>> GetCommendsAsync(int id, string username)
        {
            var models = await context.Comments
                .Where(r => r.ReviewId == id)
                .ToArrayAsync();

            var reviews = models
                .Select(r => new CommentsViewModel()
                {
                    Id = r.Id,
                    Username = username,
                    Content = r.Content,
                });

            return reviews;
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

        public async Task<ReadReviewModel> ReadReview(int Id, IEnumerable<CommentsViewModel> comments)
        {
            var review = await context.Reviews
                .Where(r => r.Id == Id)
                .Select(r => new ReadReviewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Content = r.Content,
                    Comments = comments.ToList(),
                }) 
                .FirstOrDefaultAsync();
            
            return review;
        }

        public async Task RemoveCommentAsync(int id)
        {
            var comment = await context.Comments
                .FirstOrDefaultAsync(r => r.Id == id);

            if(comment != null)
            {
                context.Comments.Remove(comment);
            }

            await context.SaveChangesAsync();
        }
    }
}
