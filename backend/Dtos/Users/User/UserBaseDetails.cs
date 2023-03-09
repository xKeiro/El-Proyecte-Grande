using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Users.User;

public abstract class UserBaseDetails
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public required string Username { get; set; }

    [StringLength(100)]
    public string? FirstName { get; set; }

    [StringLength(100)]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [Required]
    public required bool IsAdmin { get; set; } = false;
}