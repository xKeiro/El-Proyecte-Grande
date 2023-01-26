using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using Microsoft.AspNetCore.Http;
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
            var dietById = await _service.Find(id);
            if (dietById != null)
            {
                return StatusCode(StatusCodes.Status200OK, dietById);
            }
            return StatusCode(StatusCodes.Status404NotFound, _statusMessage.NotFound(id));
        }

    }
}
