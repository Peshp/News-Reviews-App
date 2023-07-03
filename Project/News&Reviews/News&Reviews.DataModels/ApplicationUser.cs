using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static News_Reviews.Common.UserConstants.User;

namespace News_Reviews.DataModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        { 
            Comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(UsernameMaxLength)]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
