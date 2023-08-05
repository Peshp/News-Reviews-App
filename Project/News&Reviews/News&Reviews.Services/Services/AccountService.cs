using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Account;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Forum;
using News_Reviews.Services.Interfaces;
using System;

namespace News_Reviews.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext context;

        public AccountService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<LastActivityViewModel>> GetLastActivityAsync(
            IEnumerable<CommentsViewModel> comments,
            IEnumerable<PostViewModel> posts,
            string id)
        {
            var models = await context.Users
                .Where(u => u.Id == id)
                .Select(u => new LastActivityViewModel
                {
                    Comments = comments,
                    Posts = posts,
                })
                .ToArrayAsync();

            return models;
        }

        public async Task<DisplayProfileViewModel> GetUserDetailsAsync(ApplicationUser user)
        {
            DisplayProfileViewModel model = new DisplayProfileViewModel()
            {
                UserId = user.Id,
                Username = user.UserName,
                Password = user.PasswordHash,
            };

            return model;
        }
    }
}
