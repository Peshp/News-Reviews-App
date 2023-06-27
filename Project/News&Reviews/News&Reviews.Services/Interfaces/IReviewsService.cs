using News_Reviews.Models.Models;

namespace News_Reviews.Services.Interfaces
{
    public interface IReviewsService
    {
        public Task<IEnumerable<ReviewsViewModel>> GetReviewsAsync();

        public Task<IEnumerable<PlatformViewModel>> GetPlatformAsync();

        public Task AddNewReview(ReviewFormModel model);
    }
}
