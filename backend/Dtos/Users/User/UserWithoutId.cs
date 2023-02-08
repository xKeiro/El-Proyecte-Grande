using backend.Dtos.Users.User;
using System.ComponentModel.DataAnnotations;

namespace ElProyecteGrande.Dtos.Users.User;

public class UserWithoutId : UserBaseDetails
{
    [Required]
    [DataType(DataType.Password)]
    required public string Password { get; set; }
}