using Microsoft.AspNetCore.Mvc;

namespace ElProyecteGrande.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
