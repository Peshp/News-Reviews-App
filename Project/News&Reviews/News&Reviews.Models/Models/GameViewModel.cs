using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace News_Reviews.Models.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public string Publisher { get; set; }

        public int GenreId { get; set; }

        public string Genre { get; set; }

        public string Platform { get; set; }
    }
}
