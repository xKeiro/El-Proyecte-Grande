using AutoMapper;
using ElProyecteGrande.Dtos.Ingredient;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IBasicCrudService<Ingredient> _service;
    private readonly IStatusMessageService<Ingredient> _statusMessage;
    private readonly IMapper _mapper;

    public IngredientsController(IBasicCrudService<Ingredient> ingredientService,
        IStatusMessageService<Ingredient> statusMessage,
        IMapper mapper)
    {
        _service = ingredientService;
        _statusMessage = statusMessage;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<IngredientPublic>>> GetAllIngredients()
    {
        var ingredients = await _service.GetAll();
        if (ingredients != null)
        {
            var ingredientsPublic = _mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientPublic>>(ingredients);
            return StatusCode(StatusCodes.Status200OK, ingredientsPublic);
        }
        return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IngredientPublic>> AddIngredient(IngredientWithoutId ingredientWithoutId)
    {
        var ingredient = _mapper.Map<IngredientWithoutId, Ingredient>(ingredientWithoutId);
        if (!await _service.IsUnique(ingredient))
        {
            return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
        }
        try
        {
            await _service.Add(ingredient);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
        var ingredientPublic = _mapper.Map<Ingredient, IngredientPublic>(ingredient);
        return StatusCode(StatusCodes.Status201Created, ingredientPublic);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IngredientPublic>> GetIngredientById(int id)
    {
        var ingredient = await _service.Find(id);
        if (ingredient != null)
        {
            var ingredientPublic = _mapper.Map<Ingredient, IngredientPublic>(ingredient);
            return StatusCode(StatusCodes.Status200OK, ingredientPublic);
        }
        return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IngredientPublic>> UpdateIngredientById(int id, IngredientWithoutId ingredientWithoutId)
    {
        var ingredient = await _service.Find(id);
        if (ingredient == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }
        ingredient = _mapper.Map<IngredientWithoutId, Ingredient>(ingredientWithoutId);
        if (!await _service.IsUnique(ingredient))
        {
            return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
        }
        try
        {
            await _service.Update(ingredient);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
        var ingredientPublic = _mapper.Map<Ingredient, IngredientPublic>(ingredient);
        return StatusCode(StatusCodes.Status200OK, ingredientPublic);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<StatusMessage>> DeleteIngredientById(int id)
    {
        var ingredient = await _service.Find(id);
        if (ingredient == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }
        try
        {
            await _service.Delete(ingredient);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
        return StatusCode(StatusCodes.Status200OK, _statusMessage.Deleted(id));
    }

}
