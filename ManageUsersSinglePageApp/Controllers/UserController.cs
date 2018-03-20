using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ManageUsersCoreApp.Models;

namespace ManageUsersCoreApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _apiContext;

        public UserController(IUserRepository apiContext)
        {
            _apiContext = apiContext;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var users = _apiContext.FindAll();
            //return new JsonResult(users);
            return View(users);
        }


        [HttpGet]
        public JsonResult ListAllUsers()
        {
            var users = _apiContext.FindAll();
            //return new JsonResult(users);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            _apiContext.Add(user);

            return RedirectToAction("GetAllUsers");
        }
    }
}