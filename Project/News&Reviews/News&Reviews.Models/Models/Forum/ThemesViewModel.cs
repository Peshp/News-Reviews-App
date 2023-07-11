using System.ComponentModel.DataAnnotations;

namespace News_Reviews.Models.Models.Forum
{
    public class ThemesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; } 
    }
}
