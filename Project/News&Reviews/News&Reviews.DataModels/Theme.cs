using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.ForumConstants;

namespace News_Reviews.DataModels
{
    public class Theme
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ThemeTitleMaxLength)]
        public string Title { get; set; }

        public IEnumerable<Post> Posts { get; set; } = new List<Post>();
    }
}
