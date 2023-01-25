using ElProyecteGrande.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("[controller]/api/")]
    public class DishTypeController : ControllerBase
    {
        private readonly IDishTypeService _dishTypeService;

        public DishTypeController(IDishTypeService dishTypeService)
        {
            _dishTypeService = dishTypeService;
        }
    }
}
