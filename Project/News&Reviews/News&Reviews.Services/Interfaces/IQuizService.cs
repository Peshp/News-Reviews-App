using News_Reviews.Models.Models.Quzi;

namespace News_Reviews.Services.Interfaces
{
    public interface IQuizService
    {
        //Task<IEnumerable<AnswersViewModel>> GetAnswers();

        Task<IEnumerable<QuestionsViewModel>> GetQuestions();
    }
}
