using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.Constants.QuizConstants;

namespace News_Reviews.DataModels
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(QuestionTitleMaxLength)]
        public string Title { get; set; }

        public IEnumerable<Answer> Answers { get; set; } = new HashSet<Answer>();

        public IEnumerable<UserAnswers> UserAnswers { get; set; } = new HashSet<UserAnswers>();
    }
}
