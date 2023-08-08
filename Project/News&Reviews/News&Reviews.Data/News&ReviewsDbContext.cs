using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News_Reviews.DataModels;
using News_Reviews.DataModels.DataModels;
using System.Reflection;

namespace News_Reviews.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<News> News { get; set; } = null!;

        public DbSet<Platform> Platforms { get; set; } = null!;

        public DbSet<Publisher> Publishers { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Theme> Themes { get; set; } = null!;

        public DbSet<Post> Posts { get; set; } = null!;

        public DbSet<Question> Questions { get; set; } = null!;

        public DbSet<Answer> Answers { get; set; } = null!;

        public DbSet<UserAnswers> UserAnswers { get; set; } = null!;

        //Use configuration class to fill database
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}