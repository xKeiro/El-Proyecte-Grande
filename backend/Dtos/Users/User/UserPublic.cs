using backend.Dtos.Users.User;

namespace ElProyecteGrande.Dtos.Users.User;

public class UserPublic : UserBaseDetails
{
    required public int Id { get; set; }
}