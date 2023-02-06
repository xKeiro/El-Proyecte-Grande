using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Users;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(EmailAddress), IsUnique = true)]
public class User : BaseModel
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
    public bool IsAdmin { get; set; } = false;
}