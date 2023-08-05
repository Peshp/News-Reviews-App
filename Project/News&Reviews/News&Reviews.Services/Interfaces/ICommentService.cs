using News_Reviews.Models.Models.Comments;

namespace News_Reviews.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<IEnumerable<CommentsViewModel>> GetCommentsAsync(int id);

        public Task<IEnumerable<CommentsViewModel>> GetUserCommentsAsync(string id);

        public Task AddNewCommentAsync(CommentsFormModel model, string userId);

        public Task RemoveCommentAsync(int id);
    }
}
