using News_Reviews.DataModels;
using News_Reviews.Models.Models.Account;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Reviews.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<LastActivityViewModel>> GetLastActivityAsync(
            IEnumerable<CommentsViewModel> comments,
            IEnumerable<PostViewModel> posts,
            string id);

        Task<DisplayProfileViewModel> GetUserDetailsAsync(ApplicationUser user);
    }
}
