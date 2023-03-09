using System.IdentityModel.Tokens.Jwt;
using backend.Dtos.Users.User;

namespace backend.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateJwt(UserPublic user);
    }
}
