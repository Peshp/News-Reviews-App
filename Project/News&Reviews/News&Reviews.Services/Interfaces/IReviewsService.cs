using News_Reviews.Models.Models;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Reviews;

namespace News_Reviews.Services.Interfaces
{
    public interface IReviewsService
    {
        public Task<IEnumerable<ReviewsViewModel>> GetReviewsAsync();

        public Task<IEnumerable<PlatformViewModel>> GetPlatformAsync();

        public Task AddNewReview(ReviewFormModel model);

        public Task<ReadReviewModel> ReadReview(int id, IEnumerable<CommentsViewModel> comments);

        public Task DeleteReview(int id);

        public Task EditReviewAsync(int id, ReviewEditModel model);

        public Task<ReviewEditModel> FindReviewById(int id);

        public Task<IEnumerable<CommentsViewModel>> GetCommentsAsync(string username);

        public Task AddNewCommentAsync(CommentsFormModel model, string userId);
    }
}
