using AutoMapper;
using backend.Dtos.Users.User;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService<UserPublic, UserWithoutId> _service;
        private readonly IMapper _mapper;
        private readonly IStatusMessageService<User> _statusMessage;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService<UserPublic, UserWithoutId> service, IMapper mapper, IStatusMessageService<User> statusMessage, IJwtService jwtService)
        {
            _service = service;
            _mapper = mapper;
            _statusMessage = statusMessage;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<IActionResult> Register(UserRegister newUser)
        {
            var user = _mapper.Map<UserRegister, UserWithoutId>(newUser);

            if (!await _service.IsUnique(user)) return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());

            await _service.Add(user);
            return StatusCode(StatusCodes.Status201Created, user);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(UserLogin user)
        {
            UserPublic resUser = await _service.FindForLogin(user);
            if (resUser is null) return StatusCode(StatusCodes.Status400BadRequest, new { message = "Invalid credentials!" });

            //string jwt = _jwtService.Generate(resUser.Id);
            string jwt = _jwtService.Authenticate(resUser);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            Response.Cookies.Append("username", resUser.Username, new CookieOptions
            {
                HttpOnly = true
            });

            return StatusCode(StatusCodes.Status200OK);
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            Response.Cookies.Delete("username");

            return Ok("success");
        }
    }
}
