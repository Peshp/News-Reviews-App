using News_Reviews.Models.Models.Forum;
using News_Reviews.Models.Models.News;
using News_Reviews.Models.Models.Reviews;
using System;

namespace News_Reviews.Models.Models
{
    public class HomeModel
    {
        public IEnumerable<ReviewsViewModel> Reviews { get; set; }

        public IEnumerable<NewsViewModel> News { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
