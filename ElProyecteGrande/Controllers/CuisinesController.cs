using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CuisinesController : ControllerBase
{
    private readonly IBasicCrudService<Cuisine> _service;
    private readonly IStatusMessageService<Cuisine> _statusMessage;

    public CuisinesController(IBasicCrudService<Cuisine> context, IStatusMessageService<Cuisine> statusMessage)
    {
        _service = context;
        _statusMessage = statusMessage;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<Cuisine>>> GetAllCuisines()
    {
        var cuisines = await _service.GetAll();
        if (cuisines != null)
        {
            return StatusCode(StatusCodes.Status200OK, cuisines);
        }
        return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
    public async Task<ActionResult<Cuisine>> AddCuisine(CuisineWithoutId cuisineWithoutId)
    {
        var cuisine = new Cuisine();
        cuisineWithoutId.MapTo(cuisine);
        if (!await _service.IsUnique(cuisine))
        {
            return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessage.NotUnique());
        }
        try
        {
            await _service.Add(cuisine);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }

        return StatusCode(StatusCodes.Status201Created, cuisine);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<Cuisine>> GetCuisineById(int id)
    {
        var cuisine = await _service.Find(id);
        if (cuisine != null)
        {
            return StatusCode(StatusCodes.Status200OK, cuisine);
        }
        return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
    public async Task<ActionResult<Cuisine>> UpdateCuisineById(int id, CuisineWithoutId cuisineWithoutId)
    {
        var cuisine = await _service.Find(id);
        if (cuisine == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }
        cuisineWithoutId.MapTo(cuisine);
        if (!await _service.IsUnique(cuisine))
        {
            return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessage.NotUnique());
        }
        try
        {
            await _service.Update(cuisine);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
        return StatusCode(StatusCodes.Status200OK, cuisine);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<StatusMessage>> DeleteCuisineById(int id)
    {
        var cuisine = await _service.Find(id);
        if (cuisine == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }
        try
        {
            await _service.Delete(cuisine);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
        return StatusCode(StatusCodes.Status200OK, _statusMessage.Deleted(id));
    }

}
