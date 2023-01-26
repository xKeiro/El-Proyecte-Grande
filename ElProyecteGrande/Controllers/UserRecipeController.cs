using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    public class UserRecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
