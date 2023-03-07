using System.IdentityModel.Tokens.Jwt;
using backend.Dtos.Users.User;

namespace backend.Interfaces.Services
{
    public interface IJwtService
    {
        //string Generate(int id);
        //JwtSecurityToken Verify(string jwt);
        string Authenticate(UserPublic user);
    }
}
