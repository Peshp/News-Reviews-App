using News_Reviews.DataModels.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace News_Reviews.DataModels
{
    public class ReviewComments
    {
        [ForeignKey(nameof(Review))]
        public int ReviewId { get; set; }
        public Review Review { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
