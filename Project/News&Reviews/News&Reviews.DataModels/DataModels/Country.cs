using System.ComponentModel.DataAnnotations;
using static News_Reviews.Helpers.Constants.GenreConstants;

namespace News_Reviews.DataModels.DataModels
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Name { get; set; }
        public virtual IEnumerable<City> Cities { get; set; } = new List<City>();
    }
}
