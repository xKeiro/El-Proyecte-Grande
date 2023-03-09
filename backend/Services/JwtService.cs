using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Dtos.Users.User;
using backend.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace backend.Services
{
    public class JwtService : IJwtService
    {
        private readonly string _tokenKey;

        public JwtService(string tokenKey)
        {
            _tokenKey = tokenKey;
        }

        
        //public string Generate(int id)
        //{
        //    SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenKey));
        //    SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        //    JwtHeader header = new JwtHeader(credentials);

        //    JwtPayload payload = new JwtPayload(id.ToString(), null, null ,null, DateTime.Today.AddDays(1));
        //    JwtSecurityToken securityToken = new JwtSecurityToken(header, payload);

        //    return new JwtSecurityTokenHandler().WriteToken(securityToken);
        //}

        //public JwtSecurityToken Verify(string jwt)
        //{
        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        //    byte[] key = Encoding.ASCII.GetBytes(_tokenKey);

        //    tokenHandler.ValidateToken(jwt, new TokenValidationParameters
        //    {
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateIssuerSigningKey = true,
        //        ValidateIssuer = false,
        //        ValidateAudience = false
        //    }, out SecurityToken validatedToken);

        //    return (JwtSecurityToken)validatedToken;
        //}

        public string Authenticate(UserPublic user)
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
    }
}
