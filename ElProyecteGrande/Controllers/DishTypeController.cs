using ElProyecteGrande.Interfaces.Services.Categories;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

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
    }
}
