using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static News_Reviews.Common.Constants.ForumConstants;

namespace News_Reviews.DataModels
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PostContentMaxLength)]
        public string Content { get; set; }

        public string Username { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [ForeignKey(nameof(Theme))]
        public int ThemeId { get; set; }

        public Theme Theme { get; set; }
    }
}
