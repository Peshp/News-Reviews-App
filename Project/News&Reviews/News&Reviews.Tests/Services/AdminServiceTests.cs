using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Admin;
using News_Reviews.Services.Interfaces;
using News_Reviews.Services.Services;
using System;

namespace News_Reviews.Tests.Services
{
    public class AdminServiceTests
    {
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext context;
        private IAdminService adminService;

        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "NewsReviews")
               .Options;
            context = new ApplicationDbContext(options);

            await context.Database.EnsureDeletedAsync();
            SeedInMemoryData.SeedUsers(context);
            await context.SaveChangesAsync();

            adminService = new AdminService(userManager, context);
        }

        [Test]
        public async Task GetAllModsAsync_ShouldWorkProperly()
        {
            var roleId = "0a1c1685-c05d-4186-a1a0-fbaebdb7ae79";

            var users = context.UserRoles
                .Where(u => u.RoleId == roleId);
            var actual = await adminService.GetAllModsAsync();

            Assert.That(actual.Count(), Is.EqualTo(users.Count()));
        }

        [Test]
        public async Task GetAllUsersAsync_ShouldWorkProperly()
        {
            var model = await context.Users.ToArrayAsync();
            var actual = await adminService.GetAllUsersAsync();

            Assert.That(actual.Count(), Is.EqualTo(model.Count()));
        }

        [Test]
        public async Task RemoveUserAsync_ShouldWorkProperly()
        {
            var user = await context.Users
                .FirstAsync(u => u.UserName == "pesho");
            
            await adminService.RemoveUserAsync(user.Id);
            
            var expected = await context.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            Assert.IsNull(expected);
        }
    }
}
