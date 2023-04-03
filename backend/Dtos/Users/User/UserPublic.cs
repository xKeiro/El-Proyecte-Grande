namespace backend.Dtos.Users.User;

public class UserPublic : UserBaseDetails
{
    public required int Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj != null && obj.GetType().Equals(GetType()))
        {
            var pubObj = (UserPublic)obj;
            return pubObj.Id == Id;
        }
        return false;
    }
}