using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IBasicCrudService<Ingredient> _service;
    private readonly IStatusMessageService<Ingredient> _statusMessage;

    public IngredientsController(IBasicCrudService<Ingredient> service, IStatusMessageService<Ingredient> statusMessage)
    {
        _service = service;
        _statusMessage = statusMessage;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetAllIngredients()
    {
        var ingredients = await _service.GetAll();
        if (ingredients != null)
        {
            return StatusCode(StatusCodes.Status200OK, ingredients);
        }
        return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
    public async Task<ActionResult<Ingredient>> AddIngredient(IngredientWithoutId ingredientWithoutId)
    {
        var ingredient = new Ingredient();
        ingredientWithoutId.MapTo(ingredient);
        if (!await _service.IsUnique(ingredient))
        {
            return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessage.NotUnique());
        }
        try
        {
            await _service.Add(ingredient);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }

        return StatusCode(StatusCodes.Status201Created, ingredient);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<Ingredient>> GetIngredientById(int id)
    {
        var ingredient = await _service.Find(id);
        if (ingredient != null)
        {
            return StatusCode(StatusCodes.Status200OK, ingredient);
        }
        return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
    public async Task<ActionResult<Ingredient>> UpdateIngredientById(int id, IngredientWithoutId ingredientWithoutId)
    {
        var ingredient = await _service.Find(id);
        if (ingredient == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }
        ingredientWithoutId.MapTo(ingredient);
        if (!await _service.IsUnique(ingredient))
        {
            return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessage.NotUnique());
        }
        try
        {
            await _service.Update(ingredient);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
        return StatusCode(StatusCodes.Status200OK, ingredient);
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
