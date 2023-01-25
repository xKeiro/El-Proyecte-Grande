using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Recipes;
using ElProyecteGrande.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ElProyecteGrandeContext _context;

        public RecipeController(ElProyecteGrandeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipe()
        {
            var allRecipes = await _context.Recipes
                .Include(recipe =>recipe.Categorization)
                .Include(recipe => recipe.Categorization.Diets)
                .Include(recipe => recipe.Categorization.MealTimes)
                .Include(recipe => recipe.Categorization.Cuisine)
                .Include(recipe => recipe.Categorization.DishType)
                .Include(recipe=> recipe.RecipeIngredients).ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .Select(recipe => new {
                    recipe.Id,
                    recipe.Name,
                    recipe.Description,
                    Categorization = new
                    {
                        recipe.Categorization.Cuisine,
                        recipe.Categorization.MealTimes,
                        recipe.Categorization.Diets,
                        recipe.Categorization.DishType
                    },
                    RecipeIngredients = recipe.RecipeIngredients.Select(recipeIngredient => new {
                        recipeIngredient.Amount,
                        Ingredient = new
                        {
                            recipeIngredient.Ingredient.Name
                        }
                    })
                })
                .ToListAsync();
            return Ok(allRecipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipeById(int id)
        {
            var recipeById = _context.Recipes
                .Include(recipe => recipe.Categorization)
                .Include(recipe=> recipe.Categorization.Diets)
                .Include(recipe => recipe.Categorization.MealTimes)
                .Include(recipe => recipe.Categorization.Cuisine)
                .Include(recipe => recipe.Categorization.DishType)
                .Include(recipe=>recipe.RecipeIngredients)
                .ThenInclude(recipeIngredient => recipeIngredient.Ingredient)
                .Where(recipe=>recipe.Id ==id);
            return Ok(recipeById);
        }

        /*[HttpPut]
        public async Task<ActionResult<IEnumerable<Recipe>>> UpdateRecipe(Recipe requestRecipe)
        {
            var recipeToUpdate = await _context.Recipes.FindAsync(requestRecipe.Id);
            if (recipeToUpdate == null)
            {
                return BadRequest("Recipe not found!");
            }
            recipeToUpdate.Name = requestRecipe.Name;
            recipeToUpdate.Description = requestRecipe.Description;
            recipeToUpdate.Categorization= requestRecipe.Categorization;
            recipeToUpdate.RecipeIngredients = requestRecipe.RecipeIngredients;
            await _context.SaveChangesAsync();
            var allRecipes = await _context.Recipes
                //.Include("Categorization")
                //.Include("RecipeIngredients")
                //.Include("Ingredients")
                //.Include("Cuisine")
                //.Include("MealTime")
                //.Include("Diet")
                //.Include("DishType")
                .ToListAsync();
            return Ok(allRecipes);
        }*/
    }
}
