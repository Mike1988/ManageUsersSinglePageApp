using System.Web.Mvc;

namespace ManageUsersSinglePageApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Manage Users App";

            return View();
        }
    }
}