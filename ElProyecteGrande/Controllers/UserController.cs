using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Dto.Users;
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
    }
}
