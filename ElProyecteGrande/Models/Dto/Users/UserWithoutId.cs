using System.ComponentModel.DataAnnotations;
using ElProyecteGrande.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Models.Dto.Users
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(EmailAddress), IsUnique = true)]
    public class UserWithoutId
    {
        [Required]
        public required string Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        public required bool IsAdmin { get; set; } = false;

        public void MapTo(User user)
        {
            user.Username = Username;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.EmailAddress = EmailAddress;
            user.Password = Password;
            user.IsAdmin = IsAdmin;
        }
    }
}
