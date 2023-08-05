using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Forum;
using System;

namespace News_Reviews.Models.Models.Account
{
    public class LastActivityViewModel
    {
        public IEnumerable<CommentsViewModel> Comments { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
