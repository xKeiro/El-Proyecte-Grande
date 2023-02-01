using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DietsController : ControllerBase
{
    private readonly IBasicCrudService<DietPublic, DietWithoutId> _service;
    private readonly IStatusMessageService<Diet> _statusMessage;

    public DietsController(IBasicCrudService<DietPublic, DietWithoutId> dietService,
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
            if (dietsPublic != null)
            {
                return StatusCode(StatusCodes.Status200OK, dietsPublic);
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
    public async Task<ActionResult<DietPublic>> AddDiet(DietWithoutId dietWithoutId)
    {

        try
        {
            if (!await _service.IsUnique(dietWithoutId))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            var dietPublic = await _service.Add(dietWithoutId);
            return StatusCode(StatusCodes.Status201Created, dietPublic);
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
            if (dietPublic != null)
            {
                return StatusCode(StatusCodes.Status200OK, dietPublic);
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
    public async Task<ActionResult<DietPublic>> UpdateDietById(int id, DietWithoutId dietWithoutId)
    {
        try
        {
            var dietPublicOriginal = await _service.Find(id);
            if (dietPublicOriginal == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            if (!await _service.IsUnique(dietWithoutId))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            var dietPublic = await _service.Update(id, dietWithoutId);
            return StatusCode(StatusCodes.Status200OK, dietPublic);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}
