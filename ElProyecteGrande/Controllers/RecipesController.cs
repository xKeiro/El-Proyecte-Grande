﻿using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _service;
    private readonly IStatusMessageService<Recipe> _statusMessage;

    public RecipesController(
        IRecipeService recipeService,
        IStatusMessageService<Recipe> statusMessage)
    {
        _service = recipeService;
        _statusMessage = statusMessage;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<IEnumerable<RecipePublic>>> GetFilteredRecipes([FromQuery] RecipeFilter filter)
    {
        try
        {
            var recipesPublic = await _service.GetFiltered(filter);
            return recipesPublic.Any() ? (ActionResult<IEnumerable<RecipePublic>>)StatusCode(StatusCodes.Status200OK, recipesPublic)
                : (ActionResult<IEnumerable<RecipePublic>>)StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound());
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
    public async Task<ActionResult<RecipePublic>> AddRecipe(RecipeRequest recipeRequest)
    {
        try
        {
            if (!await _service.IsUnique(recipeRequest))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }

            var recipePublic = await _service.Add(recipeRequest);
            return recipePublic == null
                ? (ActionResult<RecipePublic>)StatusCode(StatusCodes.Status409Conflict, _statusMessage.ANotExistingIdProvided())
                : (ActionResult<RecipePublic>)StatusCode(StatusCodes.Status201Created, recipePublic);
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
    public async Task<ActionResult<RecipePublic>> GetRecipeById(int id)
    {
        try
        {
            var recipePublic = await _service.Find(id);
            return recipePublic != null
                ? (ActionResult<RecipePublic>)StatusCode(StatusCodes.Status200OK, recipePublic)
                : (ActionResult<RecipePublic>)StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
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
    public async Task<ActionResult<RecipePublic>> UpdateRecipeById(int id, RecipeRequest recipeRequest)
    {
        try
        {
            var recipePublicOriginal = await _service.Find(id);
            switch (recipePublicOriginal)
            {
                case null:
                    return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }

            switch (await _service.IsUnique(recipeRequest))
            {
                case false:
                    return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }

            var recipePublic = await _service.Update(id, recipeRequest);
            return recipePublic switch
            {
                null => (ActionResult<RecipePublic>)StatusCode(StatusCodes.Status409Conflict, _statusMessage.ANotExistingIdProvided()),
                _ => (ActionResult<RecipePublic>)StatusCode(StatusCodes.Status200OK, recipePublic),
            };
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
    public async Task<ActionResult<StatusMessage>> DeleteRecipeById(int id)
    {
        try
        {
            var deleted = await _service.Delete(id);
            return !deleted
                ? (ActionResult<StatusMessage>)StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id))
                : (ActionResult<StatusMessage>)StatusCode(StatusCodes.Status200OK, _statusMessage.Deleted(id));
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
        }
    }
}