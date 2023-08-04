using News_Reviews.Data;
using News_Reviews.DataModels;

namespace News_Reviews.Tests
{
    public class SeedInMemoryData
    {
        public static void SeedUsers(ApplicationDbContext context)
        {
            var user = new List<ApplicationUser>()
            {
                new ApplicationUser
                {
                    Id = "40d45d54-4e27-4c4c-b751-0fff188c021d",
                    UserName = "pesho",
                    NormalizedUserName = "PESHO",
                    PasswordHash = "AQAAAAEAACcQAAAAEF3HewxMQfh5W03TxONHudxZ9Gyzkw5JJkAlWjSPS+ByyZGGVGXMh4TCSgtmFU9+7Q==",
                    SecurityStamp = "MOL5YNZIDEIMR65ECH5SRG2UDMPFKEIW",
                    ConcurrencyStamp = "d3ee842b-1be4-4dc2-96f9-faf06b17941c",
                    LockoutEnabled = true,
                },

                new ApplicationUser
                {
                    Id = "edf585ec-1818-4e01-86f6-1e9e64ab563b",
                    UserName = "gosho",
                    NormalizedUserName = "GOSHO",
                    PasswordHash = "AQAAAAEAACcQAAAAEDkevpUI1ZYzItKCQsOrhSJ0akM/tCaYEYAMXZpKx++Hh1dDV3hRuYP5ujUqvsL54g==",
                    SecurityStamp = "TYNYFDQMDXKLNSPYGEPLCUMYUCGFUEPI",
                    ConcurrencyStamp = "fd6ed1b3-aa61-4f78-a925-ad9d78b14b27",
                    LockoutEnabled = true,
                }
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
