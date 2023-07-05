using News_Reviews.Common.UserConstants;
using News_Reviews.DataModels.DataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static News_Reviews.Common.Constants.CommentConstants;

namespace News_Reviews.DataModels
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
    }
}
