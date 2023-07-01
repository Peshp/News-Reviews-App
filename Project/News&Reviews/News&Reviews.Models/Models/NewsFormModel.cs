using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.ReviewsConstants;
using static News_Reviews.Common.Constants.ContentConstats;

namespace News_Reviews.Models.Models
{
    public class NewsFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }


        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public int PlatformId { get; set; }

        public IEnumerable<PlatformViewModel> Platforms { get; set; }
    }
}
