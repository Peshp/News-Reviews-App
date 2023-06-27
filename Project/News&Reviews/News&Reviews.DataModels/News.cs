using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static News_Reviews.Common.Constants.ContentConstats;
using static News_Reviews.Common.Constants.ReviewsConstants;

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

        [Required]
        [ForeignKey(nameof(Platform))]
        public int PlatformId { get; set; }

        public Platform Platform { get; set; }

    }
}
