using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Admin;
using News_Reviews.Services.Interfaces;
using System;

namespace News_Reviews.Services.Services
{
    public class AdminService : IAdminService
    {
        private UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public AdminService(
            UserManager<ApplicationUser> _userManager,
            ApplicationDbContext context)
        {
            userManager = _userManager;
            this.context = context;
        }

        public async Task<IEnumerable<ApplicationUserModel>> GetAllModsAsync()
        {
            var roleId = "0a1c1685-c05d-4186-a1a0-fbaebdb7ae79";

            var model = context.UserRoles
                .Where(u => u.RoleId == roleId)
                .Select(u => new ApplicationUserModel
                {
                    Id = u.UserId,
                    Name = userManager.FindByIdAsync(u.UserId).Result.UserName,
                })
                .ToArray();

            return model;
        }

        public async Task<IEnumerable<ApplicationUserModel>> GetAllUsersAsync()
        {
            var model = await context.Users.ToArrayAsync();
        
            var users = model
                .Select(m => new ApplicationUserModel()
                {
                    Id = m.Id,
                    Name = m.UserName,
                });

            return users;
        }

        public async Task RemoveModeratorAsync(string id)
        {
            var user = await context.Users
                .FindAsync(id);

            await userManager.RemoveFromRoleAsync(user, "Moderator");
        }

        public async Task RemoveUserAsync(string id)
        {
            var user = await context.Users
                .FindAsync(id);

            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
