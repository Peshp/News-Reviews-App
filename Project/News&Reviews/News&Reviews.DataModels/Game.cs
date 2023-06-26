using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.ReviewsConstants;

namespace News_Reviews.DataModels.DataModels
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        [Required]
        public virtual Genre Genre { get; set; }


        [Required]
        [ForeignKey(nameof(Platform))]
        public int PlatformId { get; set; }

        [Required]
        public virtual Platform Platform { get; set; }
    }
}
