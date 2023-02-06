// using AutoMapper;
// using ElProyecteGrande.Interfaces.Services;
// using ElProyecteGrande.Models.Users;
// using Microsoft.AspNetCore.Mvc;

// namespace ElProyecteGrande.Controllers
// {
//    [ApiController]
//    [Route("api/[controller]")]
//    public class UserRecipeController : Controller
//    {
//        private readonly IBasicCrudService<UserRecipe> _userRecipeService;
//        private readonly IStatusMessageService<UserRecipe> _statusMessageService;
//        private readonly IMapper _mapper;

// public UserRecipeController(IBasicCrudService<UserRecipe> userRecipeService,
//            IStatusMessageService<UserRecipe> statusMessage,
//            IMapper mapper)
//        {
//            _userRecipeService = userRecipeService;
//            _statusMessageService = statusMessage;
//            _mapper = mapper;
//        }
//    }
// }