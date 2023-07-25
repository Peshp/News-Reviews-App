using News_Reviews.Models.Models.Comments;

namespace News_Reviews.Models.Models.Reviews
{
    public class ReadReviewModel
    {
        public ReadReviewModel() 
        {
            Comments = new List<CommentsViewModel>();
        }

        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<CommentsViewModel> Comments { get; set; }
    }
}
