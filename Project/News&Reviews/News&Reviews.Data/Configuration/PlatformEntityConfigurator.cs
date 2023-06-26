using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News_Reviews.DataModels.DataModels;

namespace News_Reviews.Data.Configuration
{
    public class PlatformEntityConfigurator : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.HasData(this.GeneratePlatforms());
        }

        private Platform[] GeneratePlatforms()
        {
            ICollection<Platform> platforms = new HashSet<Platform>();

            Platform platform = null;

            platform = new Platform()
            {
                Id = 1,
                Name = "PC",
            };
            platforms.Add(platform);

            platform = new Platform()
            {
                Id = 2,
                Name = "Playstation",
            };
            platforms.Add(platform);

            platform = new Platform()
            {
                Id = 3,
                Name = "Xbox",
            };
            platforms.Add(platform);

            platform = new Platform()
            {
                Id = 4,
                Name = "Phone",
            };
            platforms.Add(platform);

            platform = new Platform()
            {
                Id = 5,
                Name = "Nintendo",
            };
            platforms.Add(platform);

            return platforms.ToArray();
        }
    }
}
