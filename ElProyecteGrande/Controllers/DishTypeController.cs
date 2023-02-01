using AutoMapper;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.DishType;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishTypeController : ControllerBase
    {
        private readonly IBasicCrudService<DishType> _dishTypeService;
        private readonly IStatusMessageService<DishType> _statusMessageService;
        private readonly IMapper _mapper;

        public DishTypeController(IBasicCrudService<DishType> dishTypeService,
            IStatusMessageService<DishType> statusMessageService,
            IMapper mapper)
        {
            _dishTypeService = dishTypeService;
            _statusMessageService = statusMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<DishTypePublic>>> GetDishTypes()
        {
            List<DishType>? dishTypes = await _dishTypeService.GetAll();
            if (dishTypes is not null)
            {
                var dishTypesPublic = _mapper.Map<IEnumerable<DishType>, IEnumerable<DishTypePublic>>(dishTypes);
                return StatusCode(StatusCodes.Status200OK, dishTypesPublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NoneFound());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<ActionResult<DishTypePublic>> AddNewDishType(DishTypeWithoutId dishTypeWithoutId)
        {
            var dishType = _mapper.Map<DishTypeWithoutId, DishType>(dishTypeWithoutId);

            if (!await _dishTypeService.IsUnique(dishType))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessageService.NotUnique());
            }
            try
            {
                await _dishTypeService.Add(dishType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            var dishTypePublic = _mapper.Map<DishType, DishTypePublic>(dishType);
            return StatusCode(StatusCodes.Status201Created, dishTypePublic);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<DishTypePublic>> GetDishTypeById(int id)
        {
            DishType? dishType = await _dishTypeService.Find(id);
            if (dishType is not null)
            {
                var dishTypePublic = _mapper.Map<DishType, DishTypePublic>(dishType);
                return StatusCode(StatusCodes.Status200OK, dishTypePublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<ActionResult<DishTypePublic>> UpdateDishTypeById(int id, DishTypeWithoutId dishTypeWithoutId)
        {
            DishType? dishType = await _dishTypeService.Find(id);
            if (dishType == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
            }

            dishType = _mapper.Map(dishTypeWithoutId, dishType);
            if (!await _dishTypeService.IsUnique(dishType))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessageService.NotUnique());
            }
            try
            {
                await _dishTypeService.Update(dishType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            var dishTypePublic = _mapper.Map<DishType, DishTypePublic>(dishType);
            return StatusCode(StatusCodes.Status200OK, dishTypePublic);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<StatusMessage>> DeleteDishTypeById(int id)
        {
            DishType? dishType = await _dishTypeService.Find(id);
            if (dishType == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
            }
            try
            {
                await _dishTypeService.Delete(dishType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, _statusMessageService.Deleted(id));
        }
    }
}
