using AutoMapper;
using backend.Dtos.Users.User;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.Users;
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

        public AuthController(IUserService<UserPublic, UserWithoutId> service, IMapper mapper, IStatusMessageService<User> statusMessage)
        {
            _service = service;
            _mapper = mapper;
            _statusMessage = statusMessage;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<IActionResult> Register([FromForm] UserRegister newUser)
        {
            var user = _mapper.Map<UserRegister, UserWithoutId>(newUser);

            if (!await _service.IsUnique(user)) return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());

            await _service.Add(user);
            return StatusCode(StatusCodes.Status201Created, user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromForm] UserLogin user)
        {
            if (!await _service.FindForLogin(user)) return StatusCode(StatusCodes.Status400BadRequest, "Invalid credentials!");

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return Ok("logout");
        }
    }
}
