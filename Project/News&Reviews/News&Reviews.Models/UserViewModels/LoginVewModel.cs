using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.UserConstants.User;

namespace News_Reviews.Models.UserViewModels
{
    public class LoginVewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
