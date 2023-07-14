using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News_Reviews.DataModels;

namespace News_Reviews.Data.Configuration
{
    public class QuestionEntityConfigurator : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(GenerateQuestions());
        }

        private Question[] GenerateQuestions()
        {
            ICollection<Question> questions = new HashSet<Question>();

            Question question;

            question = new Question()
            {
                Id = 1,
                Title = "How much lifespan are you hoping to get out of a game? ",
            };
            questions.Add(question);

            question = new Question()
            {
                Id = 2,
                Title = "What do you prefer: Action or Logic? ",
            };
            questions.Add(question);

            question = new Question()
            {
                Id = 3,
                Title = "Which of these is most important to you in a game? ",
            };
            questions.Add(question);

            question = new Question()
            {
                Id = 4,
                Title = "Do you get easily bored with games? ",
            };
            questions.Add(question);

            question = new Question()
            {
                Id = 5,
                Title = "Are the music and sound options important? ",
            };
            questions.Add(question);

            question = new Question()
            {
                Id = 6,
                Title = "Which one of these games would you like to play? ",
            };
            questions.Add(question);

            question = new Question()
            {
                Id = 7,
                Title = "Next, depending on age and taste, is mature content a problem? ",
            };
            questions.Add(question);

            question = new Question()
            {
                Id = 8,
                Title = "How much of a gamer do you think you are? ",
            };
            questions.Add(question);

            question = new Question()
            {
                Id = 9,
                Title = "How many consoles do you have? ",
            };
            questions.Add(question);

            question = new Question()
            {
                Id = 10,
                Title = "Which of these films would you rather watch? ",
            };
            questions.Add(question);

            return questions.ToArray();
        }
    }
}
