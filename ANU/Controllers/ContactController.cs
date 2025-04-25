using Microsoft.AspNetCore.Mvc;
using ANU.Models;

namespace ANU.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process contact form submission
                // Send email, save to database, etc.
                
                // Redirect to thank you page or show success message
                TempData["SuccessMessage"] = "Thank you for your message. We will get back to you soon.";
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
