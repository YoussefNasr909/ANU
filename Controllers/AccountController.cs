using Microsoft.AspNetCore.Mvc;
using ANU.Models;

namespace AssiutUniversity.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, you would validate credentials against a database
                // For demo purposes, we'll just redirect to home page
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, you would save the user to a database
                // For demo purposes, we'll just redirect to login page
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            // In a real application, you would sign out the user
            return RedirectToAction("Index", "Home");
        }
    }
}
