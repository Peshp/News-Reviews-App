using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static News_Reviews.Constants.ReviewsConstants;

namespace News_Reviews.Data.DataModels
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
