using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News_Reviews.DataModels.DataModels;

namespace News_Reviews.Data.Configuration
{
    public class CityEntityConfigurator : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(this.GenerateCities());
        }

        private City[] GenerateCities()
        {
            ICollection<City> cities = new HashSet<City>();

            City city;

            city = new City()
            {
                Id = 1,
                Name = "Paris",
                CountryId = 1,
            };
            cities.Add(city);

            city = new City()
            {
                Id = 2,
                Name = "Tokio",
                CountryId = 2,
            };
            cities.Add(city);

            city = new City()
            {
                Id = 3,
                Name = "London",
                CountryId = 3,
            };
            cities.Add(city);

            city = new City()
            {
                Id = 4,
                Name = "Washington",
                CountryId = 4,
            };
            cities.Add(city);

            city = new City()
            {
                Id = 5,
                Name = "Warsaw",
                CountryId = 5,
            };
            cities.Add(city);

            return cities.ToArray();
        }
    }
}
