using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Dto.Categories;
using ElProyecteGrande.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealTimeController : ControllerBase
    {
        private readonly IBasicCrudService<MealTime> _mealTimeService;
        private readonly IStatusMessageService<MealTime> _statusMessageService;

        public MealTimeController(IBasicCrudService<MealTime> mealTimeService, IStatusMessageService<MealTime> statusMessageService)
        {
            _mealTimeService = mealTimeService;
            _statusMessageService = statusMessageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<MealTime>>> GetMealTimes()
        {
            var mealTimes = await _mealTimeService.GetAll();
            if (mealTimes is not null)
            {
                return StatusCode(StatusCodes.Status200OK, mealTimes);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NoneFound());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
        public async Task<ActionResult<MealTime>> AddNewMealTime(MealTimeWithoutIdAndCategorizations newMealTime)
        {
            MealTime mealTime = new MealTime();
            newMealTime.MapTo(mealTime);

            if (!await _mealTimeService.IsUnique(mealTime))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessageService.NotUnique());
            }
            try
            {
                await _mealTimeService.Add(mealTime);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }

            return StatusCode(StatusCodes.Status201Created, mealTime);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<MealTime>> GetMealTimeById(int id)
        {
            MealTime? mealTime = await _mealTimeService.Find(id);
            if (mealTime is not null)
            {
                return StatusCode(StatusCodes.Status200OK, mealTime);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
        public async Task<ActionResult<Cuisine>> UpdateMealTimeById(int id, MealTimeWithoutIdAndCategorizations newMealTime)
        {
            MealTime? mealTime = await _mealTimeService.Find(id);
            if (mealTime == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
            }

            newMealTime.MapTo(mealTime);
            if (!await _mealTimeService.IsUnique(mealTime))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessageService.NotUnique());
            }
            try
            {
                await _mealTimeService.Update(mealTime);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, mealTime);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<StatusMessage>> DeleteMealTimeById(int id)
        {
            MealTime? mealTime = await _mealTimeService.Find(id);
            if (mealTime == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
            }
            try
            {
                await _mealTimeService.Delete(mealTime);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, _statusMessageService.Deleted(id));
        }
    }
}
