using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static News_Reviews.Common.Constants.QuizConstants;

namespace News_Reviews.DataModels
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength()]
        public string Title { get; set; }

        public int Points { get; set; }

        [Required]
        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public IEnumerable<UserAnswers> UserAnswers { get; set; } = new HashSet<UserAnswers>();
    }
}
