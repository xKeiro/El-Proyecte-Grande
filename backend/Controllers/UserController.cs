﻿using AutoMapper;
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

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService<UserPublic, UserWithoutId> _userService;
    private readonly IStatusMessageService<User> _statusMessage;
    private readonly IRecipeService _recipeService;
    private readonly IMapper _mapper;

    public UsersController(
        IUserService<UserPublic, UserWithoutId> userService,
        IRecipeService recipeService,
        IStatusMessageService<User> statusMessage,
        IMapper mapper)
        {
        _userService = userService;
        _recipeService = recipeService;
        _statusMessage = statusMessage;
        _mapper = mapper;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<UserPublic>>> GetAllUsers()
    {
        try
        {
            var usersPublic = await _userService.GetAll();
            return StatusCode(StatusCodes.Status200OK, usersPublic);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
    public async Task<ActionResult<UserPublic>> AddUser(UserWithoutId userWithoutId)
    {
        try
        {
            switch (await _userService.IsUnique(userWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var userPublic = await _userService.Add(userWithoutId);
                    return StatusCode(StatusCodes.Status201Created, userPublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<UserPublic>> GetUserById(int id)
    {
        try
        {
            var userPublic = await _userService.Find(id);
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

            var user = await _userService.FindByUsername(username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var userRecipe = await _userService.GetUserRecipeStatusByRecipeId(recipeId);
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

            var user = await _userService.FindByUsername(username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var recipe = await _recipeService.Find(recipeId);
            if (recipe == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.ANotExistingIdProvided());
            }

            var userRecipe = await _userService.AddUserRecipe(username, recipeId, userRecipeAddNew);
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

            var user = await _userService.FindByUsername(username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }

            var recipe = await _recipeService.Find(recipeId);
            if (recipe == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.ANotExistingIdProvided());
            }

            var deleted = await _userService.RemoveUserRecipe(username, recipeId);
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

            var user = await _userService.FindByUsername(username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, _statusMessage.LoginNeeded());
            }
            var userRecipeStatus = await _userService.GetUserRecipeStatusByRecipeIdAndUsername(recipeId, username);
            return StatusCode(StatusCodes.Status200OK, userRecipeStatus);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [Authorize]
    [HttpGet("UserProfile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    public async Task<ActionResult<UserPublic>> GetUserProfile()
    {
        string username = HttpContext.User.Identity.Name;
        User user = await _userService.FindByUsername(username);
        UserPublic userPublic = _mapper.Map<User, UserPublic>(user);

        return userPublic switch
        {
            null => StatusCode(StatusCodes.Status404NotFound, _statusMessage.GenericError()),
            _ => StatusCode(StatusCodes.Status200OK, userPublic)
        };
    }

    [Authorize]
    [HttpGet("{id}/liked")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<List<RecipePublic>>> GetLikedRecipes(int id)
    {
        var result = await _userService.LikedRecipes(id);
        return result == null ? NotFound() : Ok(result);
    }

    [Authorize]
    [HttpGet("{id}/saved")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<List<RecipePublic>>> GetSavedRecipes(int id)
    {
        var result = await _userService.SavedRecipes(id);
        return result == null ? NotFound() : Ok(result);
    }

    [Authorize]
    [HttpGet("{id}/disliked")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<List<RecipePublic>>> GetDislikedRecipes(int id)
    {
        var result = await _userService.DislikedRecipes(id);
        return result == null ? NotFound() : Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
    public async Task<ActionResult<UserPublic>> UpdateUserById(int id, UserWithoutId userWithoutId)
    {
        try
        {
            var userPublicOriginal = await _userService.Find(id);
            switch (userPublicOriginal)
            {
                case null:
                    return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }

            switch (await _userService.IsUnique(userWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var userPublic = await _userService.Update(id, userWithoutId);
                    return StatusCode(StatusCodes.Status200OK, userPublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<StatusMessage>> DeleteUserById(int id)
    {
        try
        {
            return await _userService.Delete(id) switch
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