using System.ComponentModel.DataAnnotations;
using static News_Reviews.Helpers.Constants.GenreConstants;

namespace News_Reviews.DataModels.DataModels
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Name { get; set; }

        public virtual IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}
