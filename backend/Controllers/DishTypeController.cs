﻿using backend.Dtos.Categories.DishType;
using backend.Dtos.Recipes.Recipe;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishTypesController : ControllerBase
{
    private readonly ICategoryService<DishTypePublic, DishTypeWithoutId> _service;
    private readonly IStatusMessageService<DishType> _statusMessage;

    public DishTypesController(
        ICategoryService<DishTypePublic, DishTypeWithoutId> dishTypeService,
        IStatusMessageService<DishType> statusMessage)
    {
        _service = dishTypeService;
        _statusMessage = statusMessage;
    }

    [HttpGet]
    [OutputCache(Duration = 120)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<DishTypePublic>>> GetAllDishTypes()
    {
        try
        {
            var dishTypesPublic = await _service.GetAll();
            return StatusCode(StatusCodes.Status200OK, dishTypesPublic);
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
    public async Task<ActionResult<DishTypePublic>> AddDishType(DishTypeWithoutId dishTypeWithoutId)
    {
        try
        {
            switch (await _service.IsUnique(dishTypeWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var dishTypePublic = await _service.Add(dishTypeWithoutId);
                    return StatusCode(StatusCodes.Status201Created, dishTypePublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpGet("{id}")]
    [OutputCache(Duration = 120)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<DishTypePublic>> GetDishTypeById(int id)
    {
        try
        {
            var dishTypePublic = await _service.Find(id);
            return dishTypePublic switch
            {
                null => StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id)),
                _ => StatusCode(StatusCodes.Status200OK, dishTypePublic)
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
    public async Task<ActionResult<DishTypePublic>> UpdateDishTypeById(int id, DishTypeWithoutId dishTypeWithoutId)
    {
        try
        {
            var dishTypePublicOriginal = await _service.Find(id);
            switch (dishTypePublicOriginal)
            {
                case null:
                    return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }

            switch (await _service.IsUnique(dishTypeWithoutId))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
                default:
                    var dishTypePublic = await _service.Update(id, dishTypeWithoutId);
                    return StatusCode(StatusCodes.Status200OK, dishTypePublic);
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpGet("{id}/recipes")]
    [OutputCache(Duration = 120)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    public async Task<ActionResult<RecipePublic>> GetRecipeByDishTypeId(int id)
    {
        try
        {
            var recipes = await _service.GetRecipes(id);
            return StatusCode(StatusCodes.Status200OK, recipes);
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}