using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.CommentConstants;

namespace News_Reviews.Models.Models.Comments
{
    public class CommentsFormModel
    {
        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }
    }
}
