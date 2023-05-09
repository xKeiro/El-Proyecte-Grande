using backend.Dtos.Recipes.Recipe;
using backend.Dtos.Users.User;
using backend.Dtos.Users.UserRecipe;
using backend.Dtos.Users.UserRecipeStatus;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService<UserPublic, UserWithoutId> _service;
    private readonly IStatusMessageService<User> _statusMessage;
    private readonly IRecipeService _recipeService;

    public UsersController(
        IUserService<UserPublic, UserWithoutId> userService,
        IRecipeService recipeService,
        IStatusMessageService<User> statusMessage
        )
    {
        _service = userService;
        _statusMessage = statusMessage;
        _recipeService = recipeService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<UserPublic>>> GetAllUsers()
    {
        try
        {
            var usersPublic = await _service.GetAll();
            return StatusCode(StatusCodes.Status200OK, usersPublic);
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

    [HttpGet("Recipes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<List<UserRecipeStatusPublic?>>> GetLoggedInUserRecipeStatus(int recipeId)
    {
        try
        {
            var username = HttpContext.User.Identity?.Name;
            if (username == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var user = await _service.FindByUsername(username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var userRecipe = await _service.GetUserRecipeStatusByRecipeId(recipeId);
            if (userRecipe == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, userRecipe);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpPost("Me/Recipes/{recipeId}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<UserRecipePublic?>> PostNewUserRecipe(int recipeId, UserRecipeAddNew userRecipeAddNew)
    {
        try
        {
            var username = HttpContext.User.Identity?.Name;
            if (username == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var user = await _service.FindByUsername(username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var recipe = await _recipeService.Find(recipeId);
            if (recipe == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.ANotExistingIdProvided());
            }

            var userRecipe = await _service.AddUserRecipe(username, recipeId, userRecipeAddNew);
            if (userRecipe == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }
            return StatusCode(StatusCodes.Status201Created, userRecipe);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpDelete("Me/Recipes/{recipeId}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult> DeleteUserRecipe(int recipeId)
    {
        try
        {
            var username = HttpContext.User.Identity?.Name;
            if (username == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var user = await _service.FindByUsername(username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var recipe = await _recipeService.Find(recipeId);
            if (recipe == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.ANotExistingIdProvided());
            }

            var deleted = await _service.RemoveUserRecipe(username, recipeId);
            if (deleted is false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpGet("Me/Recipes/{recipeId}/Status")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(StatusMessage))]
    public async Task<ActionResult<UserRecipeStatusPublic?>> GetUserRecipeStatus(int recipeId)
    {
        try
        {
            var username = HttpContext.User.Identity?.Name;
            if (username == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var user = await _service.FindByUsername(username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }
            var userRecipeStatus = await _service.GetUserRecipeStatusByRecipeIdAndUsername(recipeId, username);
            return StatusCode(StatusCodes.Status200OK, userRecipeStatus);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    // Probably will need to add User too
    [HttpGet("{id}/liked")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<List<RecipePublic>>> GetLikedRecipes(int id)
    {
        var result = await _service.LikedRecipes(id);
        return result == null ? (ActionResult<List<RecipePublic>>)NotFound() : (ActionResult<List<RecipePublic>>)Ok(result);
    }

    // Probably will need to add User too
    [HttpGet("{id}/saved")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<List<RecipePublic>>> GetSavedRecipes(int id)
    {
        var result = await _service.SavedRecipes(id);
        return result == null ? (ActionResult<List<RecipePublic>>)NotFound() : (ActionResult<List<RecipePublic>>)Ok(result);
    }

    // Probably will need to add User too
    [HttpGet("{id}/disliked")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<List<RecipePublic>>> GetDislikedRecipes(int id)
    {
        var result = await _service.DislikedRecipes(id);
        return result == null ? (ActionResult<List<RecipePublic>>)NotFound() : (ActionResult<List<RecipePublic>>)Ok(result);
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
                false => StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => StatusCode(StatusCodes.Status200OK, _statusMessage.Deleted(id)),
            };
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}