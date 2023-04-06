using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using backend.Dtos;
using backend.Dtos.Users.User;
using backend.Interfaces.Services;
using backend.Models.Users;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
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
            _tokenKey = configuration.GetValue<string>("JWT_TOKEN_KEY");
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

        public bool SendWelcomeEmail(string to, string username)
        {
            string[] scopes = { GmailService.Scope.GmailSend };
            UserCredential credential;

            using (var stream = new FileStream(
                       "./GmailAPI/client_secret.json",
                       FileMode.Open,
                       FileAccess.Read
                   ))
            {
                string credPath = "GmailAPI";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "WhatCanICook",
            });

            //Parsing HTML 
            string subject = "Welcome to What Can I Cook";
            string body = $"Greetings {username}!" +
                          "<br /><br />This is just a little welcome from us. We hope that you'll like our website and find the right recipe you're searching for." +
                          "<br /><br />Best Regards," +
                          "<br />The What Can I Cook Team :)";

            string message = $"To: {to}\r\nSubject: {subject}\r\nContent-Type: text/html;charset=utf-8\r\n\r\n{body}";
            Message newMsg = new ()
            {
                Raw = Base64UrlEncode(message)
            };
            Message response = service.Users.Messages.Send(newMsg, "me").Execute();

            if (response != null)
                return true;

            return false;
        }

        private string Base64UrlEncode(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }
    }
}
