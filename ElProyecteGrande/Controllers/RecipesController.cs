using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _service;
    private readonly IStatusMessageService<Recipe> _statusMessage;

    public RecipesController(IRecipeService recipeService,
        IStatusMessageService<Recipe> statusMessage)
    {
        _service = recipeService;
        _statusMessage = statusMessage;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<RecipePublic>>> GetFilteredRecipes([FromQuery]RecipeFilter filter)
    {
        try
        {
            var recipesPublic = await _service.GetFiltered(filter);
            if (recipesPublic.Count() > 0)
            {
                return StatusCode(StatusCodes.Status200OK, recipesPublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound());
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
    public async Task<ActionResult<RecipePublic>> AddRecipe(RecipeAddNew recipeAddNew)
    {

        try
        {
            if (!await _service.IsUnique(recipeAddNew))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            var recipePublic = await _service.Add(recipeAddNew);
            if (recipePublic == null)
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.ANotExistingIdProvided());
            }
            return StatusCode(StatusCodes.Status201Created, recipePublic);
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
    public async Task<ActionResult<RecipePublic>> GetRecipeById(int id)
    {
        try
        {
            var recipePublic = await _service.Find(id);
            if (recipePublic != null)
            {
                return StatusCode(StatusCodes.Status200OK, recipePublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
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
    public async Task<ActionResult<StatusMessage>> DeleteRecipeById(int id)
    {
        try
        {
            var deleted = await _service.Delete(id);
            if (!deleted)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            return StatusCode(StatusCodes.Status200OK, _statusMessage.Deleted(id));
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

}
