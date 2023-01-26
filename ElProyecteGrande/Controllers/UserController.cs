using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IBasicCrudService<User> _userService;
        private readonly IStatusMessageService<User> _statusMessageService;

        public UserController(IBasicCrudService<User> userService, IStatusMessageService<User> statusMessageService)
        {
            _userService = userService;
            _statusMessageService = statusMessageService;
        }
    }
}
