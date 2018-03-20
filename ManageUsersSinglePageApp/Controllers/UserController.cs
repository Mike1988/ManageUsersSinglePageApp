using System.Web.Mvc;
using ManageUsersCoreApp.Models;
using ManageUsersSinglePageApp.Extensions;

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
        public JsonResult ListAllUsers()
        {
            var users = _userRepository.FindAll();
            return Json(new { success = true, result = users }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var user = _userRepository.FindById(id);
            return Json(new { success = true, result = user }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var newUser = _userRepository.Add(user);
                return Json(new { success = true, data = newUser }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, errors = ModelState.Errors() });
            }
        }

        [HttpPost]
        public JsonResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var originalUser = _userRepository.FindById(user.Id);
                originalUser.Name = user.Name;
                originalUser.Age = user.Age;
                originalUser.Address = user.Address;
                return Json(originalUser, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, errors = ModelState.Errors() });
            }
        }
    }
}