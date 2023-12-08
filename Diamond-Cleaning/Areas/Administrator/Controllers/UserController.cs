using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Areas.Administator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {
        public IActionResult GetUsers()
        {
            return View();
        }
    }
}
