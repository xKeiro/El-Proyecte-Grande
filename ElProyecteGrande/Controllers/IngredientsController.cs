using ElProyecteGrande.Dtos.Ingredient;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IBasicCrudService<IngredientPublic, IngredientWithoutId> _service;
    private readonly IStatusMessageService<Ingredient> _statusMessage;

    public IngredientsController(IBasicCrudService<IngredientPublic, IngredientWithoutId> ingredientService,
        IStatusMessageService<Ingredient> statusMessage)
    {
        _service = ingredientService;
        _statusMessage = statusMessage;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<IngredientPublic>>> GetAllIngredients()
    {
        try
        {
            var ingredientsPublic = await _service.GetAll();
            if (ingredientsPublic != null)
            {
                return StatusCode(StatusCodes.Status200OK, ingredientsPublic);
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
    public async Task<ActionResult<IngredientPublic>> AddIngredient(IngredientWithoutId ingredientWithoutId)
    {

        try
        {
            if (!await _service.IsUnique(ingredientWithoutId))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            var ingredientPublic = await _service.Add(ingredientWithoutId);
            return StatusCode(StatusCodes.Status201Created, ingredientPublic);
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
    public async Task<ActionResult<IngredientPublic>> GetIngredientById(int id)
    {
        try
        {
            var ingredientPublic = await _service.Find(id);
            if (ingredientPublic != null)
            {
                return StatusCode(StatusCodes.Status200OK, ingredientPublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
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
    public async Task<ActionResult<IngredientPublic>> UpdateIngredientById(int id, IngredientWithoutId ingredientWithoutId)
    {
        try
        {
            var ingredientPublicOriginal = await _service.Find(id);
            if (ingredientPublicOriginal == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            if (!await _service.IsUnique(ingredientWithoutId))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            var ingredientPublic = await _service.Update(id, ingredientWithoutId);
            return StatusCode(StatusCodes.Status200OK, ingredientPublic);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}
