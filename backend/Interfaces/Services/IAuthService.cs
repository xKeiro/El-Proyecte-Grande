using backend.Dtos.Users.User;

namespace backend.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateJwt(UserPublic user);
        UserWithoutId HashPw(UserWithoutId user);
        Task<UserPublic> Authenticate(UserLogin user);
    }
}
