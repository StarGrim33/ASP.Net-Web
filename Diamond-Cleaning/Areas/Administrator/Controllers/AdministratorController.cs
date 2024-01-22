using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
