using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.ReviewsConstants;
using static News_Reviews.Common.Constants.ContentConstats;

namespace News_Reviews.Models.Models.Reviews
{
    public class ReviewEditModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public int PlatformId { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int PublisherId { get; set; }


        public IEnumerable<PlatformViewModel> Platforms { get; set; }

        public IEnumerable<GenresViewModel> Genres { get; set; }

        public IEnumerable<PublishersViewModel> Publishers { get; set; }
    }
}
