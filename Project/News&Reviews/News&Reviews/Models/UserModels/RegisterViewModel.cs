using System.ComponentModel.DataAnnotations;
using static News_Reviews.Helpers.Constants.UserConstats;

namespace News_Reviews.Models.UserModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
