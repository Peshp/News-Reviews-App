using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.CommentConstants;

namespace News_Reviews.Models.Models.Comments
{
    public class CommentsFormModel
    {
        public int Id { get; set; }

        public int ReviewId { get; set; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        public string Username { get; set; }
    }
}
