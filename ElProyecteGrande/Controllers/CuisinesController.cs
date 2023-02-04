using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CuisinesController : ControllerBase
{
    private readonly ICategoryService<CuisinePublic, CuisineWithoutId> _service;
    private readonly IStatusMessageService<Cuisine> _statusMessage;

    public CuisinesController(
        ICategoryService<CuisinePublic, CuisineWithoutId> cuisineService,
        IStatusMessageService<Cuisine> statusMessage)
    {
        _service = cuisineService;
        _statusMessage = statusMessage;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<CuisinePublic>>> GetAllCuisines()
    {
        try
        {
            var cuisinesPublic = await _service.GetAll();
            return cuisinesPublic switch
            {
                null => (ActionResult<IEnumerable<CuisinePublic>>)StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound()),
                _ => (ActionResult<IEnumerable<CuisinePublic>>)StatusCode(StatusCodes.Status200OK, cuisinesPublic)
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
    public async Task<ActionResult<CuisinePublic>> AddCuisine(CuisineWithoutId cuisineWithoutId)
    {

        try
        {
            switch (await _service.IsUnique(cuisineWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var cuisinePublic = await _service.Add(cuisineWithoutId);
                    return StatusCode(StatusCodes.Status201Created, cuisinePublic);
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
    public async Task<ActionResult<CuisinePublic>> GetCuisineById(int id)
    {
        try
        {
            var cuisinePublic = await _service.Find(id);
            return cuisinePublic switch
            {
                null => (ActionResult<CuisinePublic>)StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => (ActionResult<CuisinePublic>)StatusCode(StatusCodes.Status200OK, cuisinePublic)
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
    public async Task<ActionResult<CuisinePublic>> UpdateCuisineById(int id, CuisineWithoutId cuisineWithoutId)
    {
        try
        {
            var cuisinePublicOriginal = await _service.Find(id);
            switch (cuisinePublicOriginal)
            {
                case null:
                    return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            switch (await _service.IsUnique(cuisineWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var cuisinePublic = await _service.Update(id, cuisineWithoutId);
                    return StatusCode(StatusCodes.Status200OK, cuisinePublic);
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
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<RecipePublic>> GetRecipeByCuisineId(int id)
    {
        try
        {
            var recipes = await _service.GetRecipes(id);
            return recipes switch
            {
                null => StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => StatusCode(StatusCodes.Status200OK, recipes)
            };

        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}
