using AutoMapper;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.MealTime;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealTimeController : ControllerBase
    {
        private readonly IBasicCrudService<MealTime> _mealTimeService;
        private readonly IStatusMessageService<MealTime> _statusMessageService;
        private readonly IMapper _mapper;

        public MealTimeController(IBasicCrudService<MealTime> mealTimeService,
            IStatusMessageService<MealTime> statusMessageService,
            IMapper mapper)
        {
            _mealTimeService = mealTimeService;
            _statusMessageService = statusMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<MealTimePublic>>> GetMealTimes()
        {
            var mealTimes = await _mealTimeService.GetAll();
            if (mealTimes is not null)
            {
                var mealTimesPublic = _mapper.Map<IEnumerable<MealTime>, IEnumerable<MealTimePublic>>(mealTimes);
                return StatusCode(StatusCodes.Status200OK, mealTimesPublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NoneFound());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<ActionResult<MealTimePublic>> AddNewMealTime(MealTimeWithoutId newMealTime)
        {
            var mealTime = _mapper.Map<MealTimeWithoutId, MealTime>(newMealTime);
            if (!await _mealTimeService.IsUnique(mealTime))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessageService.NotUnique());
            }
            try
            {
                await _mealTimeService.Add(mealTime);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            var mealTimePublic = _mapper.Map<MealTime, MealTimePublic>(mealTime);
            return StatusCode(StatusCodes.Status201Created, mealTimePublic);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<MealTimePublic>> GetMealTimeById(int id)
        {
            MealTime? mealTime = await _mealTimeService.Find(id);
            if (mealTime is not null)
            {
                var mealTimePublic = _mapper.Map<MealTime, MealTimePublic>(mealTime);
                return StatusCode(StatusCodes.Status200OK, mealTimePublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<ActionResult<MealTimePublic>> UpdateMealTimeById(int id, MealTimeWithoutId newMealTime)
        {
            MealTime? mealTime = await _mealTimeService.Find(id);
            if (mealTime == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
            }

            mealTime = _mapper.Map<MealTimeWithoutId, MealTime>(newMealTime);
            if (!await _mealTimeService.IsUnique(mealTime))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessageService.NotUnique());
            }
            try
            {
                await _mealTimeService.Update(mealTime);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            var mealTimePublic = _mapper.Map<MealTime, MealTimePublic>(mealTime);
            return StatusCode(StatusCodes.Status200OK, mealTimePublic);
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
