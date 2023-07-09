using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.ForumConstants;

namespace News_Reviews.Models.Models.Forum
{
    public class ThemesFormModel
    {
        public int Id { get; set; }

        [StringLength(ThemeTitleMaxLength, MinimumLength = ThemeTitleMinLength)]
        [Required]
        public string Title { get; set; }
    }
}
