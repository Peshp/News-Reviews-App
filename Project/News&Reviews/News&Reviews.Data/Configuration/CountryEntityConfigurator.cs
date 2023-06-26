using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News_Reviews.DataModels.DataModels;

namespace News_Reviews.Data.Configuration
{
    public class CountryEntityConfigurator : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(this.GenerateCountries());
        }

        private Country[] GenerateCountries()
        {
            ICollection<Country> countries = new HashSet<Country>();

            Country country;

            country = new Country()
            {
                Id = 1,
                Name = "France",
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 2,
                Name = "Japan",
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 3,
                Name = "England"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 4,
                Name = "USA",
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 5,
                Name = "Poland",
            };
            countries.Add(country);

            return countries.ToArray();
        }
    }
}
