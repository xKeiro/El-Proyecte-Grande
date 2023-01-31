using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Users.User;

public class UserWithoutId : UserBaseDetails
{
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
