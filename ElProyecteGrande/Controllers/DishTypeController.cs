using ElProyecteGrande.Interfaces.Services.Categories;
using ElProyecteGrande.Models.Categories;
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

        [Route("[action]")]
        [HttpPatch]
        public async Task<IResult> UpdateDishType(string dishTypeName, [FromBody] string newDishTypeName)
        {
            DishType mealTimeToChange = await _dishTypeService.GetDishTypeByName(dishTypeName);
            if (mealTimeToChange is null) return Results.NotFound($"We don't have this Dish Type: {dishTypeName}!");

            mealTimeToChange.Name = newDishTypeName;
            _dishTypeService.UpdateDishType(mealTimeToChange);
            return Results.Ok($"{dishTypeName} has been successfully updated to {newDishTypeName}.");
        }
    }
}
