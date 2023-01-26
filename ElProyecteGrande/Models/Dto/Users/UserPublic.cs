using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Models.Dto.Users
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(EmailAddress), IsUnique = true)]
    public class UserPublic
    {
        public required int Id { get; set; }
        public required string Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public required string EmailAddress { get; set; }

        public bool IsAdmin { get; set; }
    }
}
