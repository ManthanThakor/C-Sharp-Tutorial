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

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // Updated AccountController.cs - Register method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if email already exists
                    var existingUser = _userRepo.Validate(new Login { EmailAddress = model.EmailAddress });
                    if (existingUser != null)
                    {
                        ModelState.AddModelError("EmailAddress", "Email address is already in use.");
                        return View(model);
                    }

                    // Register the user
                    var user = _userRepo.Register(model);
                    if (user != null)
                    {
                        await _userManager.SignInAsync(HttpContext, user, isPresent: true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred during registration. Please try again.");
                    // Log the exception details here
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = _userRepo.Validate(model);
                if (user != null)
                {
                    await _userManager.SignInAsync(HttpContext, user, isPresent: true);
                    return !string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)
                        ? Redirect(returnUrl)
                        : RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            var userClaims = User.Claims.ToDictionary(x => x.Type, x => x.Value);
            return View(userClaims);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _userManager.SignOutAsync(HttpContext);
            return RedirectToAction("Login");
        }
    }
}