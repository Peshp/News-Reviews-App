using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static News_Reviews.Helpers.Constants.UserConstats;

namespace News_Reviews.DataModels.UserModels
{
    public class User : IdentityUser
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string Username { get; set; }
    }
}
