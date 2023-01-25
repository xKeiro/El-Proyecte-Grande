using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Services.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("[controller]/api/")]
    public class DishTypeController : ControllerBase
    {
        private readonly IDishTypeService _dishTypeService;

        public DishTypeController(IDishTypeService dishTypeService)
        {
            _dishTypeService = dishTypeService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<DishType>> GetDishTypes()
        {
            IEnumerable<DishType> mealTimes = await _dishTypeService.GetAllDishType();
            return mealTimes;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IResult> AddNewDishType([FromBody] string dishTypeName)
        {
            try
            {
                await _dishTypeService.AddDishType(new DishType { Name = dishTypeName });
                return Results.Ok($"{dishTypeName} has been added to the Dish Types.");
            }
            catch (DbUpdateException)
            {
                return Results.Conflict($"We already have this Dish Type: {dishTypeName}!");
            }
        }
    }
}
