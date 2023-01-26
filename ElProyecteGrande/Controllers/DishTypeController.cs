using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Dto.Categories;
using ElProyecteGrande.Models.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishTypeController : ControllerBase
    {
        private readonly IBasicCrudService<DishType> _dishTypeService;
        private readonly IStatusMessageService<DishType> _statusMessageService;

        public DishTypeController(IBasicCrudService<DishType> dishTypeService, IStatusMessageService<DishType> statusMessageService)
        {
            _dishTypeService = dishTypeService;
            _statusMessageService = statusMessageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<DishType>>> GetDishTypes()
        {
            List<DishType>? dishTypes = await _dishTypeService.GetAll();
            if (dishTypes is not null)
            {
                return StatusCode(StatusCodes.Status200OK, dishTypes);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NoneFound());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
        public async Task<ActionResult<Cuisine>> AddNewDishType(DishTypeWithoutId newDishType)
        {
            DishType dishType = new DishType();
            newDishType.MapTo(dishType);

            if (!await _dishTypeService.IsUnique(dishType))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessageService.NotUnique());
            }
            try
            {
                await _dishTypeService.Add(dishType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }

            return StatusCode(StatusCodes.Status201Created, dishType);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
        public async Task<ActionResult<Cuisine>> UpdateDishTypeById(int id, DishTypeWithoutId newDishType)
        {
            DishType? dishType = await _dishTypeService.Find(id);
            if (dishType == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessageService.NotFound(id));
            }

            newDishType.MapTo(dishType);
            if (!await _dishTypeService.IsUnique(dishType))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessageService.NotUnique());
            }
            try
            {
                await _dishTypeService.Update(dishType);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessageService.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, dishType);
        }
    }
}
