using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.GenreConstants;

namespace News_Reviews.DataModels.DataModels
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Name { get; set; }
    }
}
