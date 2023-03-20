using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Users.User
{
    public class UserLogin
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public required string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
