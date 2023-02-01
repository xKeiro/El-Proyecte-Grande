using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishTypesController : ControllerBase
{
    private readonly IBasicCrudService<DishTypePublic, DishTypeWithoutId> _service;
    private readonly IStatusMessageService<DishType> _statusMessage;

    public DishTypesController(IBasicCrudService<DishTypePublic, DishTypeWithoutId> dishTypeService,
        IStatusMessageService<DishType> statusMessage)
    {
        _service = dishTypeService;
        _statusMessage = statusMessage;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<DishTypePublic>>> GetAllDishTypes()
    {
        try
        {
            var dishTypesPublic = await _service.GetAll();
            if (dishTypesPublic != null)
            {
                return StatusCode(StatusCodes.Status200OK, dishTypesPublic);
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
    public async Task<ActionResult<DishTypePublic>> AddDishType(DishTypeWithoutId dishTypeWithoutId)
    {

        try
        {
            if (!await _service.IsUnique(dishTypeWithoutId))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            var dishTypePublic = await _service.Add(dishTypeWithoutId);
            return StatusCode(StatusCodes.Status201Created, dishTypePublic);
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
    public async Task<ActionResult<DishTypePublic>> GetDishTypeById(int id)
    {
        try
        {
            var dishTypePublic = await _service.Find(id);
            if (dishTypePublic != null)
            {
                return StatusCode(StatusCodes.Status200OK, dishTypePublic);
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
    public async Task<ActionResult<DishTypePublic>> UpdateDishTypeById(int id, DishTypeWithoutId dishTypeWithoutId)
    {
        try
        {
            var dishTypePublicOriginal = await _service.Find(id);
            if (dishTypePublicOriginal == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            if (!await _service.IsUnique(dishTypeWithoutId))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            var dishTypePublic = await _service.Update(id, dishTypeWithoutId);
            return StatusCode(StatusCodes.Status200OK, dishTypePublic);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}
