using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietsController : ControllerBase
    {
        private readonly IBasicCrudService<Diet> _service;
        private readonly IStatusMessageService<Diet> _statusMessage;

        public DietsController(IBasicCrudService<Diet> service, IStatusMessageService<Diet> statusMessage)
        {
            _service = service;
            _statusMessage = statusMessage;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<Diet>>> GetAllDiets()
        {
            var diets = await _service.GetAll();
            if (diets != null)
            {
                return StatusCode(StatusCodes.Status200OK, diets);
            }
            
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NoneFound());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<IEnumerable<Diet>>> GetDietById(int id)
        {
            var diet = await _service.Find(id);

            if (diet != null)
            {
                return StatusCode(StatusCodes.Status200OK, diet);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
        public async Task<ActionResult<Diet>> AddDiet(DietWithoutIdAndRecipes dietWithoutIdAndCategorization)
        {
            var diet = new Diet();
            dietWithoutIdAndCategorization.MapTo(diet);
            if (!await _service.IsUnique(diet))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessage.NotUnique());
            }
            try
            {
                await _service.Add(diet);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }

            return StatusCode(StatusCodes.Status201Created, diet);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(StatusMessage))]
        public async Task<ActionResult<Diet>> UpdateDietById(int id, DietWithoutIdAndRecipes dietWithoutIdAndCategorization)
        {
            var diet = await _service.Find(id);
            if (diet == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            dietWithoutIdAndCategorization.MapTo(diet);
            if (!await _service.IsUnique(diet))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, _statusMessage.NotUnique());
            }
            try
            {
                await _service.Update(diet);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, diet);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(StatusMessage))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(StatusMessage))]
        public async Task<ActionResult<StatusMessage>> DeleteDietById(int id)
        {
            var dietById = await _service.Find(id);
            if (dietById == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
            }
            try
            {
                await _service.Delete(dietById);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, _statusMessage.GenericError());
            }
            return StatusCode(StatusCodes.Status200OK, _statusMessage.Deleted(id));
        }

    }
}
