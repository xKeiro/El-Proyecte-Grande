using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealTimesController : ControllerBase
{
    private readonly ICategoryService<MealTimePublic, MealTimeWithoutId> _service;
    private readonly IStatusMessageService<MealTime> _statusMessage;

    public MealTimesController(
        ICategoryService<MealTimePublic, MealTimeWithoutId> mealTimeService,
        IStatusMessageService<MealTime> statusMessage)
    {
        _service = mealTimeService;
        _statusMessage = statusMessage;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<MealTimePublic>>> GetAllMealTimes()
    {
        try
        {
            var mealTimesPublic = await _service.GetAll();
            return StatusCode(StatusCodes.Status200OK, mealTimesPublic);
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
    public async Task<ActionResult<MealTimePublic>> AddMealTime(MealTimeWithoutId mealTimeWithoutId)
    {
        try
        {
            switch (await _service.IsUnique(mealTimeWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var mealTimePublic = await _service.Add(mealTimeWithoutId);
                    return StatusCode(StatusCodes.Status201Created, mealTimePublic);
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
    public async Task<ActionResult<MealTimePublic>> GetMealTimeById(int id)
    {
        try
        {
            var mealTimePublic = await _service.Find(id);
            return mealTimePublic switch
            {
                null => StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => StatusCode(StatusCodes.Status200OK, mealTimePublic)
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
    public async Task<ActionResult<MealTimePublic>> UpdateMealTimeById(int id, MealTimeWithoutId mealTimeWithoutId)
    {
        try
        {
            var mealTimePublicOriginal = await _service.Find(id);
            switch (mealTimePublicOriginal)
            {
                case null:
                    return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }

            switch (await _service.IsUnique(mealTimeWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var mealTimePublic = await _service.Update(id, mealTimeWithoutId);
                    return StatusCode(StatusCodes.Status200OK, mealTimePublic);
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
    public async Task<ActionResult<RecipePublic>> GetRecipeByMealTimeId(int id)
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