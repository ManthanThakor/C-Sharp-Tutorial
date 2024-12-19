using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.InsertUser(user);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user);
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _userRepository.GetUser();
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        public ActionResult Edit(int id)
        {
            UserModel model = _userRepository.GetUserById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.UpdateUser(user);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            UserModel user = _userRepository.GetUserById(id);
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                UserModel user = _userRepository.GetUserById(id);
                _userRepository.DeleteUser(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                new System.Web.Routing.RouteValueDictionary {
          { "id", id },
          { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }

    }
}