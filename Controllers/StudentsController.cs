using Microsoft.AspNetCore.Mvc;
using ANU.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ANU.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Profile(int id)
        {
            // This would typically come from a database
            var student = new Student
            {
                Id = id,
                StudentId = "20210123",
                FullName = "Ahmed Mohamed",
                Email = "ahmed.mohamed@assiut.edu",
                Faculty = "Faculty of Computers & Artificial Intelligence",
                Department = "Computer Science",
                Year = 3,
                ProfileImageUrl = "/css/anu/student-profile.jpg",
                EnrolledCourses = new List<Course>
                {
                    new Course { Id = 1, Code = "CS301", Name = "Data Structures" },
                    new Course { Id = 2, Code = "CS302", Name = "Algorithms" },
                    new Course { Id = 3, Code = "CS303", Name = "Database Systems" }
                }
            };

            return View(student);
        }

        public IActionResult Register()
        {
            // Populate faculties dropdown
            ViewBag.Faculties = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Faculty of Computers & Artificial Intelligence" },
                new SelectListItem { Value = "2", Text = "Faculty of Medicine" },
                new SelectListItem { Value = "3", Text = "Faculty of Engineering & Applied Sciences" }
            };

            return View();
        }

        [HttpPost]
        public IActionResult Register(StudentRegistration model)
        {
            if (ModelState.IsValid)
            {
                // Process registration
                // Redirect to success page or login
                return RedirectToAction("Profile", new { id = 1 });
            }

            // Repopulate faculties dropdown
            ViewBag.Faculties = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Faculty of Computers & Artificial Intelligence" },
                new SelectListItem { Value = "2", Text = "Faculty of Medicine" },
                new SelectListItem { Value = "3", Text = "Faculty of Engineering & Applied Sciences" }
            };

            return View(model);
        }
    }
}
