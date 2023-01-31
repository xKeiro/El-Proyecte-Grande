using AutoMapper;
using ElProyecteGrande.Dtos.Users.User;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStatusMessageService<User> _statusMessageService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,
            IStatusMessageService<User> userStatusMessageService,
            IMapper mapper)
        {
            _userService = userService;
            _statusMessageService = userStatusMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<UserPublic>>> GetUsers()
        {
            var usersPublic = await _userService.GetAll();
            if (usersPublic is not null)
            {
                return StatusCode(StatusCodes.Status200OK, usersPublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NoneFound());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<ActionResult<UserPublic>> AddNewUser(UserWithoutId userWithoutId)
        {
            var user = _mapper.Map<UserWithoutId, User>(userWithoutId);

            if (!await _userService.IsUnique(user))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessageService.NotUnique());
            }
            try
            {
                await _userService.Add(user);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            var userPublic = _mapper.Map<User, UserPublic>(user);
            return StatusCode(StatusCodes.Status201Created, userPublic);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<ActionResult<UserPublic>> UpdateUserById(int id, UserWithoutId userWithoutId)
        {
            User? user = await _userService.Find(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
            }

            user = _mapper.Map<UserWithoutId, User>(userWithoutId);
            if (!await _userService.IsUnique(user))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessageService.NotUnique());
            }
            try
            {
                await _userService.Update(user);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            var userPublic = _mapper.Map<User, UserPublic>(user);
            return StatusCode(StatusCodes.Status200OK, userPublic);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<UserPublic>> GetUserById(int id)
        {
            var userPublic = await _userService.FindPublic(id);
            if (userPublic is not null)
            {
                return StatusCode(StatusCodes.Status200OK, userPublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<StatusMessage>> DeleteUserById(int id)
        {
            User? user = await _userService.Find(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
            }
            try
            {
                await _userService.Delete(user);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, _statusMessageService.Deleted(id));
        }
    }
}
