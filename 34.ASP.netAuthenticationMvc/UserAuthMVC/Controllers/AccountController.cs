using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UserAuthMVC.Models.ViewModels;
using UserAuthMVC.Repository.IRepo;
using UserAuthMVC.Repository.Utilitie;
using System.Threading.Tasks;
using System.Linq;

namespace UserAuthMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly IUserManager _userManager;

        public AccountController(IUserRepo userRepo, IUserManager userManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepo.Register(model);

                if (user != null)
                {
                    await _userManager.SignInAsync(HttpContext, user, isPresent: true); // auto sign-in after registration
                    return RedirectToAction("Index", "Home");  // Redirect to Home page after successful registration
                }
            }

            return View(model);
        }

        // GET: Account/Profile
        [Authorize]
        public IActionResult Profile()
        {
            var userClaims = this.User.Claims.ToDictionary(x => x.Type, x => x.Value);
            return View(userClaims);  // Passing user claims to the view
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepo.Validate(model);

                if (user != null)
                {
                    await _userManager.SignInAsync(HttpContext, user, isPresent: true);  // Sign-in user
                    return RedirectToAction("Index", "Home");  // Redirect to Home page after successful login
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            await _userManager.SignOutAsync(HttpContext);  // Sign out the user
            return RedirectToAction("Login", "Account");  // Redirect to login page after logout
        }
    }
}
