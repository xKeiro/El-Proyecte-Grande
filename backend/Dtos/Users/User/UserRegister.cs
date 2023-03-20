using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Users.User
{
    public class UserRegister : UserLogin
    {
        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string EmailAddress { get; set; }
    }
}
