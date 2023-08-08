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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                GenreId = model.GenreId,
                PublisherId = model.PublisherId,
            };

            context.Reviews.Add(review);
            await context.SaveChangesAsync();
        }

        public async Task DeleteReview(int id)
        {
            var review = await context.Reviews
                .FirstOrDefaultAsync(r => r.Id == id);

            if (review != null)
            {
                context.Reviews.Remove(review);
            }

            await context.SaveChangesAsync();
        }

        public async Task EditReviewAsync(int id, ReviewFormModel model)
        {
            var review = await context.Reviews
                .FirstOrDefaultAsync (r => r.Id == id);

            if (review != null)
            {
                review.Id = model.Id;
                review.Title = model.Title;
                review.Content = model.Content;
                review.ImageURL = model.ImageURL;
                review.PlatformId = model.PlatformId;
                review.GenreId = model.GenreId;
                review.PublisherId = model.PublisherId;
            }

            await context.SaveChangesAsync();
        }

        public async Task<ReviewFormModel> FindReviewById(int id)
        {
            var review = await context.Reviews
                .Include(r => r.Platform)
                .Include(r => r.Genre)
                .Include (r => r.Publisher)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (review != null)
            {
                ReviewFormModel reviewModel = new ReviewFormModel()
                {
                    Id = review.Id,
                    Title = review.Title,
                    Content = review.Content,
                    ImageURL = review.ImageURL,
                    PlatformId = review.PlatformId,
                    GenreId = review.GenreId,
                    PublisherId = review.PublisherId,
                };

                return reviewModel;
            }
            return null;
        }


        public async Task<IEnumerable<GenresViewModel>> GetGenresAsync()
        {
            var models = await context.Genres.ToArrayAsync();

            var genres = models
                .Select(g => new GenresViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                });

            return genres;
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

        public async Task<IEnumerable<PublishersViewModel>> GetPublishersAsync()
        {
            var models = await context.Publishers.ToArrayAsync();

            var publishers = models
                .Select(p => new PublishersViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                });

            return publishers;
        }

        public async Task<IEnumerable<ReviewsViewModel>> GetReviewsAsync()
        {
            var models = await context.Reviews
                .Include(r => r.Platform)
                .Include(r => r.Genre)
                .Include(r => r.Publisher)
                .ToArrayAsync();

            var reviews = models
                .Select(r => new ReviewsViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Content = r.Content,
                    ImageURL = r.ImageURL,
                    Platform = r.Platform.Name,
                    Genre = r.Genre.Name,
                    Publisher = r.Publisher.Name,
                });

            return reviews;
        }

        public async Task<ReadReviewModel> ReadReview(int Id, IEnumerable<CommentsViewModel> comments)
        {
            //Get review with that id, fill the view model with appropriate data and comments.
            //Comments need to visualize the comments of the current review
            var review = await context.Reviews
                .Where(r => r.Id == Id)
                .Select(r => new ReadReviewModel
                {
                    Id = r.Id,
                    ImageUrl = r.ImageURL,
                    Title = r.Title,
                    Content = r.Content,
                    Comments = comments.ToList(),
                }) 
                .FirstOrDefaultAsync();
            
            return review;
        }

        
    }
}
