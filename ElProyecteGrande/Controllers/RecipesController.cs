using AutoMapper;
using ElProyecteGrande.Dtos.Recipes.Recipe;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IBasicCrudService<Recipe> _service;
        private readonly IStatusMessageService<Recipe> _statusMessage;
        private readonly IMapper _mapper;

        public RecipesController(IBasicCrudService<Recipe> recipeService,
            IStatusMessageService<Recipe> statusMessage,
            IMapper mapper)
        {
            _service = recipeService;
            _statusMessage = statusMessage;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<RecipePublic>>> GetAllRecipes()
        {
            var recipes = await _service.GetAll();
            if (recipes != null)
            {
                var recipesPublic = _mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipePublic>>(recipes);
                return StatusCode(StatusCodes.Status200OK, recipesPublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<RecipePublic>> RecipeById(int id)
        {
            var recipe = await _service.Find(id);
            if (recipe != null)
            {
                var recipePublic = _mapper.Map<Recipe, RecipePublic>(recipe);
                return StatusCode(StatusCodes.Status200OK, recipePublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<StatusMessage>> DeleteRecipeById(int id)
        {
            var recipeToDelete = await _service.Find(id);
            if (recipeToDelete == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            try
            {
                await _service.Delete(recipeToDelete);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, _statusMessage.Deleted(id));
        }
    }
}
