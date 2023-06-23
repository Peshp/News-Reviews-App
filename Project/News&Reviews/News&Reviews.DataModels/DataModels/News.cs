using System.ComponentModel.DataAnnotations;
using static News_Reviews.Helpers.Constants.ContentConstats;
using static News_Reviews.Helpers.Constants.ReviewsConstants;

namespace News_Reviews.DataModels.DataModels
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        public DateTime Data { get; set; }
    }
}
