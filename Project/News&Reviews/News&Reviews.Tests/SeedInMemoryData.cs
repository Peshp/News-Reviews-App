using Microsoft.AspNetCore.Identity;
using News_Reviews.Data;
using News_Reviews.DataModels;

namespace News_Reviews.Tests
{
    public class SeedInMemoryData
    {
        public static void SeedUsers(ApplicationDbContext context)
        {
            var user = new ApplicationUser
            {
                Id = "40d45d54-4e27-4c4c-b751-0fff188c021d",
                UserName = "pesho",
                NormalizedUserName = "PESHO",
                PasswordHash = "AQAAAAEAACcQAAAAEF3HewxMQfh5W03TxONHudxZ9Gyzkw5JJkAlWjSPS+ByyZGGVGXMh4TCSgtmFU9+7Q==",
                SecurityStamp = "MOL5YNZIDEIMR65ECH5SRG2UDMPFKEIW",
                ConcurrencyStamp = "d3ee842b-1be4-4dc2-96f9-faf06b17941c",
                LockoutEnabled = true,
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
