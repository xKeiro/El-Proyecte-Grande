using backend.Dtos.Ingredient;
using backend.Interfaces.Services;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IBasicCrudService<IngredientPublic, IngredientWithoutId> _service;
    private readonly IStatusMessageService<Ingredient> _statusMessage;

    public IngredientsController(
        IBasicCrudService<IngredientPublic, IngredientWithoutId> ingredientService,
        IStatusMessageService<Ingredient> statusMessage)
    {
        _service = ingredientService;
        _statusMessage = statusMessage;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<IngredientPublic>>> GetAllIngredients()
    {
        try
        {
            var ingredientsPublic = await _service.GetAll();
            return StatusCode(StatusCodes.Status200OK, ingredientsPublic);
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
    public async Task<ActionResult<IngredientPublic>> AddIngredient(IngredientWithoutId ingredientWithoutId)
    {
        try
        {
            switch (await _service.IsUnique(ingredientWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var ingredientPublic = await _service.Add(ingredientWithoutId);
                    return StatusCode(StatusCodes.Status201Created, ingredientPublic);
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
    public async Task<ActionResult<IngredientPublic>> GetIngredientById(int id)
    {
        try
        {
            var ingredientPublic = await _service.Find(id);
            return ingredientPublic switch
            {
                null => StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => StatusCode(StatusCodes.Status200OK, ingredientPublic)
            };
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [Authorize(Roles = "Admin")]
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
            switch (ingredientPublicOriginal)
            {
                case null:
                    return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }

            switch (await _service.IsUnique(ingredientWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var ingredientPublic = await _service.Update(id, ingredientWithoutId);
                    return StatusCode(StatusCodes.Status200OK, ingredientPublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}