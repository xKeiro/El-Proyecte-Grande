using ElProyecteGrande.Interfaces.Services;
using ElProyecteGrande.Models;
using ElProyecteGrande.Models.Categories;
using ElProyecteGrande.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRecipeController : Controller
    {
        private readonly IBasicCrudService<UserRecipe> _userRecipeService;
        private readonly IStatusMessageService<UserRecipe> _statusMessageService;
        
        public UserRecipeController(IBasicCrudService<UserRecipe> userRecipeService, IStatusMessageService<UserRecipe> statusMessage)
        {
            _userRecipeService = userRecipeService;
            _statusMessageService = statusMessage;
        }
    }
}
