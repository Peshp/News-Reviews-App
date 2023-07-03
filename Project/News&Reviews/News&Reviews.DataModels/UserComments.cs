using System.ComponentModel.DataAnnotations.Schema;

namespace News_Reviews.DataModels
{
    public class UserComments
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
