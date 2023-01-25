using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Services;
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
    }
}
