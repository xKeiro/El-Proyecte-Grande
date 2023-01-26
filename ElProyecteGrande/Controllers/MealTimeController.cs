using ElProyecteGrande.Interfaces.Services.Categories;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("[controller]/api/")]
    public class MealTimeController : ControllerBase
    {
        private readonly IMealTimeService _mealTimeService;

        public MealTimeController(IMealTimeService mealTimeService)
        {
            _mealTimeService = mealTimeService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IEnumerable<MealTime>> GetMealTimes()
        {
            IEnumerable<MealTime> mealTimes = await _mealTimeService.GetAllMealTime();
            return mealTimes;
        }
    }
}
