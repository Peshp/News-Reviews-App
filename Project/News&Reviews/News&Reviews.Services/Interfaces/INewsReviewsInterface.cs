using News_Reviews.Models.Models;

namespace News_Reviews.Services.Interfaces
{
    public interface INewsReviewsInterface
    {
        public Task<IEnumerable<ReviewsViewModel>> GetReviewsAsync();
    }
}
