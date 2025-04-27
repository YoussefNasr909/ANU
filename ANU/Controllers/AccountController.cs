using Microsoft.AspNetCore.Mvc;
using ANU.Models;
using System.Threading.Tasks;
using ANU.Services;
using Microsoft.AspNetCore.Authorization;

namespace ANU.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _authService.AuthenticateAsync(model.Email, model.Password);
                if (user != null)
                {
                    await _authService.SignInAsync(user, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool success = await _authService.RegisterUserAsync(
                    model.Email,
                    model.Password,
                    model.FirstName,
                    model.LastName);

                if (success)
                {
                    // Log the user in after registration
                    var user = await _authService.AuthenticateAsync(model.Email, model.Password);
                    if (user != null)
                    {
                        await _authService.SignInAsync(user);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email is already in use.");
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
