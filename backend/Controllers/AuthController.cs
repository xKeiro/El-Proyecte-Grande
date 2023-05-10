using AutoMapper;
using backend.Dtos.Users.User;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.Users;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService<UserPublic, UserWithoutId> _userService;
        private readonly IMapper _mapper;
        private readonly IStatusMessageService<User> _statusMessage;
        private readonly IAuthService _authService;

        public AuthController(IUserService<UserPublic, UserWithoutId> userService, IMapper mapper, IStatusMessageService<User> statusMessage, IAuthService authService)
        {
            _userService = userService;
            _mapper = mapper;
            _statusMessage = statusMessage;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<IActionResult> Register(UserRegister newUser)
        {
            var user = _mapper.Map<UserRegister, UserWithoutId>(newUser);

            if (!await _userService.IsUnique(user))
            {
                bool usernameIsUnique = await _userService.IsUniqueUsername(user);
                bool emaileIsUnique = await _userService.IsUniqueEmail(user);
                return StatusCode(StatusCodes.Status409Conflict,
                    new
                    {
                        usernameMsg = !usernameIsUnique ? "This Username is already taken!" : "ok",
                        emailMsg = !emaileIsUnique ? "This Email address is already taken!" : "ok"
                    });
            }

            _authService.HashPw(user);
            UserPublic userReturn = await _userService.Add(user);
            // _authService.SendWelcomeEmail(user.EmailAddress, user.Username);
            return StatusCode(StatusCodes.Status201Created, userReturn);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(UserLogin user)
        {

            UserPublic? resUser = await _authService.Authenticate(user);
            if (resUser is null) return StatusCode(StatusCodes.Status400BadRequest, new { message = "Invalid credentials!" });
            
            string jwt = _authService.GenerateJwt(resUser);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });

            return StatusCode(StatusCodes.Status200OK, resUser);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });

            return StatusCode(StatusCodes.Status200OK, "You successfully logged out!");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task GoogleLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme);
        }
    }
}
