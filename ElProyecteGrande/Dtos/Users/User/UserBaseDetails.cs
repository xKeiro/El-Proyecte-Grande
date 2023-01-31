using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Users.User;

public abstract class UserBaseDetails
{
    [Required]
    public required string Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [Required]
    public required bool IsAdmin { get; set; } = false;
}
