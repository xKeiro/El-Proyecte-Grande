using backend.Dtos.Categories.Diet;
using backend.Dtos.Recipes.Recipe;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DietsController : ControllerBase
{
    private readonly ICategoryService<DietPublic, DietWithoutId> _service;
    private readonly IStatusMessageService<Diet> _statusMessage;

    public DietsController(
        ICategoryService<DietPublic, DietWithoutId> dietService,
        IStatusMessageService<Diet> statusMessage)
    {
        _service = dietService;
        _statusMessage = statusMessage;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<DietPublic>>> GetAllDiets()
    {
        try
        {
            var dietsPublic = await _service.GetAll();
            return StatusCode(StatusCodes.Status200OK, dietsPublic);
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
    public async Task<ActionResult<DietPublic>> AddDiet(DietWithoutId dietWithoutId)
    {
        try
        {
            switch (await _service.IsUnique(dietWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var dietPublic = await _service.Add(dietWithoutId);
                    return StatusCode(StatusCodes.Status201Created, dietPublic);
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
    public async Task<ActionResult<DietPublic>> GetDietById(int id)
    {
        try
        {
            var dietPublic = await _service.Find(id);
            return dietPublic switch
            {
                null => StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => StatusCode(StatusCodes.Status200OK, dietPublic)
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
    public async Task<ActionResult<DietPublic>> UpdateDietById(int id, DietWithoutId dietWithoutId)
    {
        try
        {
            var dietPublicOriginal = await _service.Find(id);
            switch (dietPublicOriginal)
            {
                case null:
                    return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }

            switch (await _service.IsUnique(dietWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var dietPublic = await _service.Update(id, dietWithoutId);
                    return StatusCode(StatusCodes.Status200OK, dietPublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpGet("{id}/recipes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    public async Task<ActionResult<RecipePublic>> GetRecipeByDietId(int id)
    {
        try
        {
            var recipes = await _service.GetRecipes(id);
            return StatusCode(StatusCodes.Status200OK, recipes);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}