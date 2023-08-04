using News_Reviews.Models.Models;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Reviews;

namespace News_Reviews.Services.Interfaces
{
    public interface IReviewsService
    {
        public Task<IEnumerable<ReviewsViewModel>> GetReviewsAsync();

        public Task<IEnumerable<PlatformViewModel>> GetPlatformAsync();

        public Task<IEnumerable<GenresViewModel>> GetGenresAsync();

        public Task<IEnumerable<PublishersViewModel>> GetPublishersAsync();

        public Task AddNewReview(ReviewFormModel model);

        public Task<ReadReviewModel> ReadReview(int id, IEnumerable<CommentsViewModel> comments);

        public Task DeleteReview(int id);

        public Task EditReviewAsync(int id, ReviewFormModel model);

        public Task<ReviewFormModel> FindReviewById(int id);       
    }
}
