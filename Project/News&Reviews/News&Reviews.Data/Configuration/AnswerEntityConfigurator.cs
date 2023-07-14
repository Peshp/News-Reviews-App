using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News_Reviews.DataModels;

namespace News_Reviews.Data.Configuration
{
    public class AnswerEntityConfigurator : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasData(GenerateAnswers());
        }

        private Answer[] GenerateAnswers()
        {
            ICollection<Answer> answers = new HashSet<Answer>();

            Answer answer;

            // questionId = 1;
            answer = new Answer()
            {
                Id = 1,
                Title = "More than a week",
                Points = 1,
                QuestionId = 1,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 2,
                Title = "Months and months",
                Points = 2,
                QuestionId = 1,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 3,
                Title = "Short campaign with an online multiplayer option to play for months",
                Points = 3,
                QuestionId = 1,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 4,
                Title = "Something short",
                Points = 4,
                QuestionId = 1,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 5,
                Title = "Not particularly bothered",
                Points = 5,
                QuestionId = 1,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 6,
                Title = "I want a game that takes up all my time but that I've finished within a few weeks.",
                Points = 6,
                QuestionId = 1,
            };
            answers.Add(answer);


            //question id = 2

            answer = new Answer()
            {
                Id = 7,
                Title = "Logic all the way. Games should be a strategic plan.",
                Points = 1,
                QuestionId = 2,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 8,
                Title = "A good balance of both",
                Points = 2,
                QuestionId = 2,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 9,
                Title = "Mostly action, I guess.",
                Points = 3,
                QuestionId = 2,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 10,
                Title = "I like logic, such as simple puzzles.",
                Points = 4,
                QuestionId = 2,
            };
            answers.Add(answer);

            //question id = 3

            answer = new Answer()
            {
                Id = 11,
                Title = "Strategy and logic",
                Points = 1,
                QuestionId = 3,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 12,
                Title = "Multiplayer options",
                Points = 2,
                QuestionId = 3,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 13,
                Title = "A vast array of guns and weapons ",
                Points = 3,
                QuestionId = 3,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 14,
                Title = "Good puzzles and short, simple gameplay",
                Points = 4,
                QuestionId = 3,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 15,
                Title = "Lots of action, combat, and story",
                Points = 5,
                QuestionId = 3,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 16,
                Title = "Leveling up and ability to change features ",
                Points = 6,
                QuestionId = 3,
            };
            answers.Add(answer);

            //question id = 4

            answer = new Answer()
            {
                Id = 17,
                Title = "Nope! Not at all",
                Points = 1,
                QuestionId = 4,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 18,
                Title = "A little. It depends on my mood.",
                Points = 2,
                QuestionId = 4,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 19,
                Title = "Sometimes",
                Points = 3,
                QuestionId = 4,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 20,
                Title = "Yes! Long and complicated games bore me. ",
                Points = 4,
                QuestionId = 4,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 21,
                Title = "Yeah, a little. I need something to constantly require my attention.",
                Points = 5,
                QuestionId = 4,
            };
            answers.Add(answer);

            //question id = 5

            answer = new Answer()
            {
                Id = 22,
                Title = "I like a good choice of current songs playing in the background.",
                Points = 1,
                QuestionId = 5,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 23,
                Title = "I don't really pay any attention to it. ",
                Points = 2,
                QuestionId = 5,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 24,
                Title = "Nope, I usually play with the sound off.",
                Points = 3,
                QuestionId = 5,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 25,
                Title = "To an extent, it's not a make-or-break deal for me, however.",
                Points = 4,
                QuestionId = 5,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 26,
                Title = "Yes! A good soundtrack can be vital!",
                Points = 5,
                QuestionId = 5,
            };
            answers.Add(answer);

            //question id = 6

            answer = new Answer()
            {
                Id = 27,
                Title = "Final Fantasy XV",
                Points = 1,
                QuestionId = 6,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 28,
                Title = "Rise of the Tomb Raider",
                Points = 2,
                QuestionId = 6,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 29,
                Title = "Fifa 18",
                Points = 3,
                QuestionId = 6,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 30,
                Title = "Gears Of War",
                Points = 4,
                QuestionId = 6,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 31,
                Title = "Civilization VI",
                Points = 5,
                QuestionId = 6,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 32,
                Title = "Candy Crush",
                Points = 5,
                QuestionId = 6,
            };
            answers.Add(answer);

            //question id = 7

            answer = new Answer()
            {
                Id = 33,
                Title = "I'm not bothered, but I would rather there not be too graphic images and language. ",
                Points = 1,
                QuestionId = 7,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 34,
                Title = "Why is mature content a problem when I only play sports games?",
                Points = 2,
                QuestionId = 7,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 35,
                Title = "Nope, not at all! I want blood, gore, and plenty of bad language.",
                Points = 3,
                QuestionId = 7,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 36,
                Title = "Yes, definitely. I do not approve of those elements.",
                Points = 4,
                QuestionId = 7,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 37,
                Title = "No, not a problem. I feel there is a time and place for everything.",
                Points = 5,
                QuestionId = 7,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 38,
                Title = "I'm not bothered either way.",
                Points = 5,
                QuestionId = 7,
            };
            answers.Add(answer);

            // question id = 8

            answer = new Answer()
            {
                Id = 39,
                Title = "It's all I do!",
                Points = 1,
                QuestionId = 8,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 40,
                Title = "I do enjoy my games",
                Points = 2,
                QuestionId = 8,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 41,
                Title = "Very casual, I hardly ever play.",
                Points = 3,
                QuestionId = 8,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 42,
                Title = "I'm a pretty hardcore gamer.",
                Points = 4,
                QuestionId = 8,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 43,
                Title = "I guess I'm a casual gamer. I usually only play sports games. ",
                Points = 5,
                QuestionId = 8,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 44,
                Title = "I love video games and play them whenever I have the time. ",
                Points = 5,
                QuestionId = 8,
            };
            answers.Add(answer);

            // question id = 9

            answer = new Answer()
            {
                Id = 45,
                Title = "Only Pc",
                Points = 1,
                QuestionId = 9,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 46,
                Title = "Just one that I play on a regular basis. ",
                Points = 2,
                QuestionId = 9,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 47,
                Title = "I have one or two consoles.",
                Points = 3,
                QuestionId = 9,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 48,
                Title = "Consoles? No, I play games on my phone.",
                Points = 4,
                QuestionId = 9,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 49,
                Title = "I have most consoles that have ever been released!",
                Points = 5,
                QuestionId = 9,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 50,
                Title = "I have plenty of consoles. ",
                Points = 6,
                QuestionId = 9,
            };
            answers.Add(answer);

            // question id = 10

            answer = new Answer()
            {
                Id = 51,
                Title = "13th Warrior",
                Points = 1,
                QuestionId = 10,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 52,
                Title = "Any Given Sunday",
                Points = 2,
                QuestionId = 10,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 53,
                Title = "Die Hard",
                Points = 3,
                QuestionId = 10,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 54,
                Title = "The Da Vinci Code",
                Points = 4,
                QuestionId = 10,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 55,
                Title = "Lord Of The Rings",
                Points = 5,
                QuestionId = 10,
            };
            answers.Add(answer);

            answer = new Answer()
            {
                Id = 56,
                Title = "The Butterfly Effect",
                Points = 6,
                QuestionId = 10,
            };
            answers.Add(answer);

            return answers.ToArray();
        }
    }
}
