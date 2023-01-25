using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Services.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Route("[action]")]
        [HttpPost]
        public async Task<IResult> AddNewMealTime([FromBody] string mealTimeName)
        {
            try
            {
                await _mealTimeService.AddMealTime(new MealTime { Name = mealTimeName });
                return Results.Ok($"{mealTimeName} has been added to the Meal Times.");
            }
            catch (DbUpdateException)
            {
                return Results.Conflict($"We already have this Meal Time: {mealTimeName}!");
            }
        }
    }
}
