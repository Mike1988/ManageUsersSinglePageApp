using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ManageUsersCoreApp.Models;

namespace ManageUsersCoreApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var users = _userRepository.FindAll();
            return View(users);
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var user = _userRepository.FindById(id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(User user)
        {
            var originalUser = _userRepository.FindById(user.Id);
            originalUser.Name = user.Name;
            originalUser.Age = user.Age;
            originalUser.Address = user.Address;
            return Json(originalUser, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListAllUsers()
        {
            var users = _userRepository.FindAll();
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
            _userRepository.Add(user);

            return RedirectToAction("GetAllUsers");
        }
    }
}