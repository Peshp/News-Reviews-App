using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News_Reviews.DataModels.DataModels;

namespace News_Reviews.Data.Configuration
{
    public class GenreEntityConfigurator : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(this.GenerateGenres());
        }

        private Genre[] GenerateGenres()
        {
            ICollection<Genre> genres = new HashSet<Genre>();

            Genre genre = null;

            genre = new Genre()
            {
                Id = 1,
                Name = "RPG",
            };
            genres.Add(genre);

            genre = new Genre()
            {
                Id = 2,
                Name = "Shooter",
            };
            genres.Add(genre);

            genre = new Genre()
            {
                Id = 3,
                Name = "Puzzle",
            };
            genres.Add(genre);

            genre = new Genre()
            {
                Id = 4,
                Name = "Horror",
            };
            genres.Add(genre);

            genre = new Genre()
            {
                Id = 5,
                Name = "Stealth",
            };
            genres.Add(genre);

            genre = new Genre()
            {
                Id = 6,
                Name = "Action",
            };
            genres.Add(genre);

            return genres.ToArray();
        }
    }
}
