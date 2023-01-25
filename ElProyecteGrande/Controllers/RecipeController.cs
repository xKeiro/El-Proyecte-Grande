using ElProyecteGrande.Models.Recipes;
using ElProyecteGrande.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Recipe>>> GetAllRecipe()
        {
            var recipes = await _context.Recipes.ToListAsync();
            return Ok(recipes);
        }
    }
}
