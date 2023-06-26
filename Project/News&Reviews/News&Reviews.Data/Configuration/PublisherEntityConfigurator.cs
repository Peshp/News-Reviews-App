using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News_Reviews.DataModels.DataModels;

namespace News_Reviews.Data.Configuration
{
    public class PublisherEntityConfigurator : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(this.GeneratePublishers());
        }

        private Publisher[] GeneratePublishers()
        {
            ICollection<Publisher> publishers = new HashSet<Publisher>();

            Publisher publisher = null;

            publisher = new Publisher()
            {
                Id = 1,
                Name = "Ubisoft",
                CountryId = 1,
                CityId = 1,
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 2,
                Name = "EA",
                CountryId = 4,
                CityId = 4,
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 3,
                Name = "Sony",
                CountryId = 2,
                CityId = 2,
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 4,
                Name = "From software",
                CountryId = 2,
                CityId = 2,
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 5,
                Name = "CDPR",
                CountryId = 5,
                CityId = 5,
            };
            publishers.Add(publisher);

            return publishers.ToArray();
        }
    }
}
