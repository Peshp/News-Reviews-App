using System.ComponentModel.DataAnnotations;

namespace News_Reviews.Models.Models.News
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Data { get; set; }
        public string Platform { get; set; }
    }
}
