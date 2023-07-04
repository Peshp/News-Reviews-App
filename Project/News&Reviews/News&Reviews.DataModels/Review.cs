using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static News_Reviews.Common.Constants.ReviewsConstants;
using static News_Reviews.Common.Constants.ContentConstats;

namespace News_Reviews.DataModels.DataModels
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        [ForeignKey(nameof(Platform))]
        public int PlatformId { get; set; }

        [Required]
        public Platform Platform { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
