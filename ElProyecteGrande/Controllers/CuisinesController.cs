using AutoMapper;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CuisinesController : ControllerBase
{
    private readonly IBasicCrudService<Cuisine> _service;
    private readonly IStatusMessageService<Cuisine> _statusMessage;
    private readonly IMapper _mapper;

    public CuisinesController(IBasicCrudService<Cuisine> cuisineService, 
        IStatusMessageService<Cuisine> statusMessage, 
        IMapper mapper)
    {
        _service = cuisineService;
        _statusMessage = statusMessage;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<CuisineFull>>> GetAllCuisines()
    {
        var cuisines = await _service.GetAll();
        if (cuisines != null)
        {
            var cuisinesFull = _mapper.Map<IEnumerable<Cuisine>, IEnumerable<CuisineFull>>(cuisines);
            return StatusCode(StatusCodes.Status200OK, cuisinesFull);
        }
        return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
    public async Task<ActionResult<CuisineFull>> AddCuisine(CuisineWithoutId cuisineWithoutId)
    {
        var cuisine = _mapper.Map<CuisineWithoutId, Cuisine>(cuisineWithoutId);
        if (!await _service.IsUnique(cuisine))
        {
            return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
        }
        try
        {
            await _service.Add(cuisine);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }

        var cuisineFull = _mapper.Map<Cuisine, CuisineFull>(cuisine);
        return StatusCode(StatusCodes.Status201Created, cuisineFull);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<CuisineFull>> GetCuisineById(int id)
    {
        var cuisine = await _service.Find(id);
        if (cuisine != null)
        {
            var cuisineFull = _mapper.Map<Cuisine, CuisineFull>(cuisine);
            return StatusCode(StatusCodes.Status200OK, cuisineFull);
        }
        return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
    public async Task<ActionResult<CuisineFull>> UpdateCuisineById(int id, CuisineWithoutId cuisineWithoutId)
    {
        var cuisine = await _service.Find(id);
        if (cuisine == null)
        {
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }
        cuisine = _mapper.Map<CuisineWithoutId, Cuisine>(cuisineWithoutId);
        if (!await _service.IsUnique(cuisine))
        {
            return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
        }
        try
        {
            await _service.Update(cuisine);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
        var cuisineFull = _mapper.Map<Cuisine, CuisineFull>(cuisine);
        return StatusCode(StatusCodes.Status200OK, cuisineFull);
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
