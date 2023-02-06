using ElProyecteGrande.Dtos.Users.User;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService<UserPublic, UserWithoutId> _service;
    private readonly IStatusMessageService<User> _statusMessage;

    public UsersController(
        IUserService<UserPublic, UserWithoutId> userService,
        IStatusMessageService<User> statusMessage)
    {
        _service = userService;
        _statusMessage = statusMessage;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<UserPublic>>> GetAllUsers()
    {
        try
        {
            var usersPublic = await _service.GetAll();
            return usersPublic switch
            {
                null => StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound()),
                _ => StatusCode(StatusCodes.Status200OK, usersPublic)
            };
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
    public async Task<ActionResult<UserPublic>> AddUser(UserWithoutId userWithoutId)
    {
        try
        {
            switch (await _service.IsUnique(userWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var userPublic = await _service.Add(userWithoutId);
                    return StatusCode(StatusCodes.Status201Created, userPublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<UserPublic>> GetUserById(int id)
    {
        try
        {
            var userPublic = await _service.Find(id);
            return userPublic switch
            {
                null => StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => StatusCode(StatusCodes.Status200OK, userPublic)
            };
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
    public async Task<ActionResult<UserPublic>> UpdateUserById(int id, UserWithoutId userWithoutId)
    {
        try
        {
            var userPublicOriginal = await _service.Find(id);
            switch (userPublicOriginal)
            {
                case null:
                    return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }

            switch (await _service.IsUnique(userWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var userPublic = await _service.Update(id, userWithoutId);
                    return StatusCode(StatusCodes.Status200OK, userPublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<StatusMessage>> DeleteUserById(int id)
    {
        try
        {
            return await _service.Delete(id) switch
            {
                false => (ActionResult<StatusMessage>)StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => (ActionResult<StatusMessage>)StatusCode(StatusCodes.Status200OK, _statusMessage.Deleted(id)),
            };
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}