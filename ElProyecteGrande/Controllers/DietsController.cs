using AutoMapper;
using ElProyecteGrande.Dtos.Categories.Cuisine;
using ElProyecteGrande.Dtos.Categories.Diet;
using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietsController : ControllerBase
    {
        private readonly IBasicCrudService<Diet> _service;
        private readonly IStatusMessageService<Diet> _statusMessage;
        private readonly IMapper _mapper;

        public DietsController(IBasicCrudService<Diet> service,
            IStatusMessageService<Diet> statusMessage,
            IMapper mapper)
        {
            _service = service;
            _statusMessage = statusMessage;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<DietPublic>>> GetAllDiets()
        {
            var diets = await _service.GetAll();
            if (diets != null)
            {
                var dietsPublic = _mapper.Map<IEnumerable<Diet>, IEnumerable<DietPublic>>(diets);
                return StatusCode(StatusCodes.Status200OK, dietsPublic);
            }

            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<DietPublic>>> GetDietById(int id)
        {
            var diet = await _service.Find(id);

            if (diet != null)
            {
                var dietPublic = _mapper.Map<Diet, DietPublic>(diet);
                return StatusCode(StatusCodes.Status200OK, dietPublic);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<ActionResult<DietPublic>> AddDiet(DietWithoutId dietWithoutId)
        {
            var diet = _mapper.Map<DietWithoutId, Diet>(dietWithoutId);
            if (!await _service.IsUnique(diet))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            try
            {
                await _service.Add(diet);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }
            var dietPublic = _mapper.Map<Diet, DietPublic>(diet);
            return StatusCode(StatusCodes.Status201Created, dietPublic);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(StatusMessage))]
        public async Task<ActionResult<DietPublic>> UpdateDietById(int id, DietWithoutId dietWithoutId)
        {
            var diet = await _service.Find(id);
            if (diet == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            diet = _mapper.Map(dietWithoutId, diet);
            if (!await _service.IsUnique(diet))
            {
                return StatusCode(StatusCodes.Status409Conflict, _statusMessage.NotUnique());
            }
            try
            {
                await _service.Update(diet);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }
            var dietPublic = _mapper.Map<Diet, DietPublic>(diet);
            return StatusCode(StatusCodes.Status200OK, dietPublic);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<StatusMessage>> DeleteDietById(int id)
        {
            var diet = await _service.Find(id);
            if (diet == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            try
            {
                await _service.Delete(diet);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, _statusMessage.Deleted(id));
        }

    }
}
