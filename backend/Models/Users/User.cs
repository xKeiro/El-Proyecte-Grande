using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Models.Users;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(EmailAddress), IsUnique = true)]
public class User : BaseModel
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public required string Username { get; set; }

    [StringLength(100, MinimumLength = 2)]
    public string? FirstName { get; set; }

    [StringLength(100, MinimumLength = 2)]
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