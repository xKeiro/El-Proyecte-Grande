using backend.Dtos.Categories.Cuisine;
using backend.Dtos.Ingredient;
using backend.Dtos.Recipes.PreparationStep;
using backend.Interfaces.Services;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PreparationStepController : ControllerBase
{
    private readonly IBasicCrudService<PreparationStepPublic, PreparationStepWithoutId> _service;
    private readonly IStatusMessageService<PreparationStep> _statusMessage;

    public PreparationStepController(
        IBasicCrudService<PreparationStepPublic, PreparationStepWithoutId> preparationStepService,
        IStatusMessageService<PreparationStep> statusMessage)
    {
        _service = preparationStepService;
        _statusMessage = statusMessage;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
    public async Task<ActionResult<PreparationStepPublic>> AddPreparationStep(PreparationStepWithoutId preparationStepWithoutId)
    {
        try
        {
            switch (await _service.IsUnique(preparationStepWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var preparationStepPublic = await _service.Add(preparationStepWithoutId);
                    return StatusCode(StatusCodes.Status201Created, preparationStepPublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<PreparationStepPublic>>> GetAllPreparationSteps()
    {
        try
        {
            var preparationStepsPublic = await _service.GetAll();
            return StatusCode(StatusCodes.Status200OK, preparationStepsPublic);
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
    public async Task<ActionResult<PreparationStepPublic>> GetPreparationStepById(int id)
    {
        try
        {
            var preparationStepPublic = await _service.Find(id);
            return preparationStepPublic switch
            {
                null => StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => StatusCode(StatusCodes.Status200OK, preparationStepPublic)
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
    public async Task<ActionResult<PreparationStepPublic>> UpdatePreparationStepById(int id, PreparationStepWithoutId preparationStepWithoutId)
    {
        try
        {
            var preparationStepPublicOriginal = await _service.Find(id);
            switch (preparationStepPublicOriginal)
            {
                case null:
                    return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }

            switch (await _service.IsUnique(preparationStepWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var preparationStepPublic = await _service.Update(id, preparationStepWithoutId);
                    return StatusCode(StatusCodes.Status200OK, preparationStepPublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}