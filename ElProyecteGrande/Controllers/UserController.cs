using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
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
