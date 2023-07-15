namespace News_Reviews.Models.Models.Quzi
{
    public class QuestionsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<AnswersViewModel> Answers { get; set; }
    }
}
