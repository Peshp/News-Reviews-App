using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News_Reviews.DataModels.DataModels;

namespace News_Reviews.Data.Configuration
{
    public class GameEntityConfigurator : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(this.GenerateGames());
        }

        private Game[] GenerateGames()
        {
            ICollection<Game> games = new HashSet<Game>();

            Game game;

            game = new Game()
            {
                Id = 1,
                Name = "Call of Duty",
                PublishDate = new DateTime(2019, 10, 25),
                PublisherId = 2,
                GenreId = 2,
                PlatformId = 1,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 2,
                Name = "Assansin's creed",
                PublishDate = new DateTime(2007, 11, 13),
                PublisherId = 1,
                GenreId = 5,
                PlatformId = 1,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 3,
                Name = "God of War",
                PublishDate = new DateTime(2005, 3, 22),
                PublisherId = 3,
                GenreId = 6,
                PlatformId = 2,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 4,
                Name = "Elden ring",
                PublishDate = new DateTime(2022, 2, 25),
                PublisherId = 4,
                GenreId = 1,
                PlatformId = 3,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 5,
                Name = "Bloodborn",
                PublishDate = new DateTime(2015, 3, 24),
                PublisherId = 4,
                GenreId = 1,
                PlatformId = 2,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 6,
                Name = "The witcher 3",
                PublishDate = new DateTime(2015, 5, 18),
                PublisherId = 5,
                GenreId = 1,
                PlatformId = 1,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 7,
                Name = "Super Mario",
                PublishDate = new DateTime(2017, 10, 27),
                PublisherId = 3,
                GenreId = 3,
                PlatformId = 5,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 8,
                Name = "Call of Duty: Mobile",
                PublishDate = new DateTime(2019, 10, 1),
                PublisherId = 2,
                GenreId = 2,
                PlatformId = 4,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 9,
                Name = "Among us",
                PublishDate = new DateTime(2018, 6, 15),
                PublisherId = 3,
                GenreId = 3,
                PlatformId = 4,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 10,
                Name = "Far Cry 6",
                PublishDate = new DateTime(2021, 10, 7),
                PublisherId = 1,
                GenreId = 3,
                PlatformId = 1,
            };
            games.Add(game);

            game = new Game()
            {
                Id = 11,
                Name = "Dark Souls",
                PublishDate = new DateTime(2016, 3, 24),
                PublisherId = 4,
                GenreId = 1,
                PlatformId = 1,
            };
            games.Add(game);

            return games.ToArray();
        }
    }
}
