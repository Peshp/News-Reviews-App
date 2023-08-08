using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Services.Interfaces;
using System;
using System.Net;

namespace News_Reviews.Services.Services
{
    public class CommentService : ICommentService
    {
        private ApplicationDbContext context;

        public CommentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddNewCommentAsync(CommentsFormModel model, string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            Comment comment = new Comment()
            {
                ReviewId = model.ReviewId,
                Username = user.UserName,
                //Used for defence against XSS attack
                Content = WebUtility.HtmlEncode(model.Content),
                UserId = userId,
            };

            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentsViewModel>> GetCommentsAsync(int id)
        {
            var models = await context.Comments
                .Where(r => r.ReviewId == id)
                .ToArrayAsync();

            var comments = models
                .Select(r => new CommentsViewModel()
                {
                    Id = r.Id,
                    Username = r.Username,
                    Content = r.Content,
                });

            return comments;
        }

        public async Task<IEnumerable<CommentsViewModel>> GetUserCommentsAsync(string id)
        {
            var models = await context.Comments
                .Where(r => r.UserId == id)
                .ToArrayAsync();

            var comments = models
                .Select(r => new CommentsViewModel()
                {
                    Id = r.Id,
                    Username = r.Username,
                    Content = r.Content,
                });

            return comments;
        }

        public async Task RemoveCommentAsync(int id)
        {
            var comment = await context.Comments
                .FirstOrDefaultAsync(r => r.Id == id);

            if (comment != null)
            {
                context.Comments.Remove(comment);
            }

            await context.SaveChangesAsync();
        }
    }       
}
