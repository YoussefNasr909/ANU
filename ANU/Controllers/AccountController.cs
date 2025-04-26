using Microsoft.AspNetCore.Mvc;
using ANU.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ANU.Controllers
{
    public class AccountController : Controller
    {
        // STEP 1: Add private fields for UserManager and SignInManager
        // private readonly UserManager<ApplicationUser> _userManager;
        // private readonly SignInManager<ApplicationUser> _signInManager;

        // STEP 2: Inject the managers through constructor injection
        // public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        // {
        //     _userManager = userManager;
        //     _signInManager = signInManager;
        // }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // STEP 3: Replace with actual authentication logic
                // var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                // if (result.Succeeded)
                // {
                //     return RedirectToAction("Index", "Home");
                // }
                // else
                // {
                //     ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //     return View(model);
                // }

                // For demo purposes, we'll create a simple authentication cookie
                // In a real application, you would validate against a database
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim(ClaimTypes.Email, model.Email),
                    // Add more claims as needed
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Redirect to home page after successful login
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
                // STEP 4: Replace with actual user registration logic
                // var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                // var result = await _userManager.CreateAsync(user, model.Password);
                // if (result.Succeeded)
                // {
                //     await _signInManager.SignInAsync(user, isPersistent: false);
                //     return RedirectToAction("Index", "Home");
                // }
                // foreach (var error in result.Errors)
                // {
                //     ModelState.AddModelError(string.Empty, error.Description);
                // }

                // In a real application, you would save the user to a database
                // For demo purposes, we'll just redirect to login page
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            // STEP 5: Replace with actual logout logic
            // await _signInManager.SignOutAsync();
            // return RedirectToAction("Index", "Home");

            // For demo purposes, sign out using cookie authentication
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
