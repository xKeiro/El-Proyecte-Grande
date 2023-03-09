using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using backend.Dtos.Users.User;
using backend.Interfaces.Services;
using backend.Models.Users;
using Microsoft.IdentityModel.Tokens;

namespace backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly string? _tokenKey;
        private readonly IUserService<UserPublic, UserWithoutId> _userService;
        private readonly IMapper _mapper;

        public AuthService(IUserService<UserPublic, UserWithoutId> userService, IConfiguration configuration, IMapper mapper)
        {
            _userService = userService;
            _tokenKey = configuration.GetValue<string>("JwtTokenKey");
            _mapper = mapper;
        }

        public string GenerateJwt(UserPublic user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenKey);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (ClaimTypes.Name, user.Username),
                    new (ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public UserWithoutId HashPw(UserWithoutId user)
        {
            string pwHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = pwHash;
            return user;
        }

        public async Task<UserPublic> Authenticate(UserLogin user)
        {
            User? resUser = await _userService.FindByUsername(user.Username);
            bool verified = false;

            if (resUser != null)
            {
                verified = BCrypt.Net.BCrypt.Verify(user.Password, resUser.Password);
            }

            if (resUser == null || !verified) return null;
            return _mapper.Map<User, UserPublic>(resUser);
        }
    }
}
