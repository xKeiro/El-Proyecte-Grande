using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Dto.Categories;
using ElProyecteGrande.Models.Dto.Users;
using ElProyecteGrande.Models.Users;
using ElProyecteGrande.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStatusMessageService<User> _statusMessageService;

        public UserController(IUserService userService, IStatusMessageService<User> userStatusMessageService)
        {
            _userService = userService;
            _statusMessageService = userStatusMessageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<UserPublic>>> GetUsers()
        {
            List<UserPublic> users = await _userService.GetAll();
            if (users is not null)
            {
                return StatusCode(StatusCodes.Status200OK, users);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NoneFound());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
        public async Task<ActionResult<User>> AddNewUser(UserWithoutId newUser)
        {
            User user = new User();
            newUser.MapTo(user);

            if (!await _userService.IsUnique(user))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessageService.NotUnique());
            }
            try
            {
                await _userService.Add(user);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }

            return StatusCode(StatusCodes.Status201Created, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
        public async Task<ActionResult<User>> UpdateUserById(int id, UserWithoutId newUser)
        {
            User? user = await _userService.Find(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
            }

            newUser.MapTo(user);
            if (!await _userService.IsUnique(user))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessageService.NotUnique());
            }
            try
            {
                await _userService.Update(user);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<UserPublic>> GetUserById(int id)
        {
            UserPublic? user = await _userService.FindPublic(id);
            if (user is not null)
            {
                return StatusCode(StatusCodes.Status200OK, user);
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
