using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.ForumConstants;

namespace News_Reviews.Models.Models.Forum
{
    public class PostFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int ThemeId { get; set; }
    }
}
