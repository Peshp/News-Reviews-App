using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.CommentConstants;

namespace News_Reviews.Models.Models.Comments
{
    public class CommentsFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        public string UserId { get; set; }
    }
}
