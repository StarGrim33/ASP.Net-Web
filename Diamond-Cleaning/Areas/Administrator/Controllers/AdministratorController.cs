using Microsoft.AspNetCore.Mvc;

namespace Diamond_Cleaning.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class AdministratorController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
