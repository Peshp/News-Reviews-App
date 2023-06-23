using System.ComponentModel.DataAnnotations;

namespace News_Reviews.Models.UserModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
