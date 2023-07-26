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
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 2,
                Name = "EA",
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 3,
                Name = "Sony",
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 4,
                Name = "From software",
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 5,
                Name = "CDPR",
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 6,
                Name = "Techland",
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 7,
                Name = "Blizzard",
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 8,
                Name = "Rockstar",
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 9,
                Name = "Capcom",
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 10,
                Name = "Microsoft",
            };
            publishers.Add(publisher);

            publisher = new Publisher()
            {
                Id = 11,
                Name = "Square Enix",
            };
            publishers.Add(publisher);

            return publishers.ToArray();
        }
    }
}
