using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MealTimesController : ControllerBase
{
    private readonly IBasicCrudService<MealTimePublic, MealTimeWithoutId> _service;
    private readonly IStatusMessageService<MealTime> _statusMessage;

    public MealTimesController(IBasicCrudService<MealTimePublic, MealTimeWithoutId> mealTimeService,
        IStatusMessageService<MealTime> statusMessage)
    {
        _service = mealTimeService;
        _statusMessage = statusMessage;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<MealTimePublic>>> GetAllMealTimes()
    {
        try
        {
            var mealTimesPublic = await _service.GetAll();
            if (mealTimesPublic != null)
            {
                return StatusCode(StatusCodes.Status200OK, mealTimesPublic);
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
    public async Task<ActionResult<MealTimePublic>> AddMealTime(MealTimeWithoutId mealTimeWithoutId)
    {

        try
        {
            if (!await _service.IsUnique(mealTimeWithoutId))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            var mealTimePublic = await _service.Add(mealTimeWithoutId);
            return StatusCode(StatusCodes.Status201Created, mealTimePublic);
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
            if (mealTimePublic != null)
            {
                return StatusCode(StatusCodes.Status200OK, mealTimePublic);
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
    public async Task<ActionResult<MealTimePublic>> UpdateMealTimeById(int id, MealTimeWithoutId mealTimeWithoutId)
    {
        try
        {
            var mealTimePublicOriginal = await _service.Find(id);
            if (mealTimePublicOriginal == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            if (!await _service.IsUnique(mealTimeWithoutId))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            var mealTimePublic = await _service.Update(id, mealTimeWithoutId);
            return StatusCode(StatusCodes.Status200OK, mealTimePublic);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}
