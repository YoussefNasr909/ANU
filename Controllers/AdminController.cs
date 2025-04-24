using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ANU.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            
            ViewBag.AdminName = "Admin User";
            ViewBag.StudentCount = 5000;
            ViewBag.FacultyCount = 10;
            ViewBag.CourseCount = 200;
            ViewBag.StaffCount = 300;

            ViewBag.RecentActivities = new List<object>
            {
                new { Timestamp = System.DateTime.Now.AddMinutes(-5), User = "Dr. Ahmed Hassan", Action = "Updated course schedule" },
                new { Timestamp = System.DateTime.Now.AddMinutes(-15), User = "Admin User", Action = "Added new student" },
                new { Timestamp = System.DateTime.Now.AddMinutes(-30), User = "Dr. Mohamed Ali", Action = "Uploaded exam results" },
                new { Timestamp = System.DateTime.Now.AddHours(-1), User = "Admin User", Action = "Created news article" },
                new { Timestamp = System.DateTime.Now.AddHours(-2), User = "Dr. Sara Ahmed", Action = "Updated faculty information" }
            };

            return View();
        }
    }
}
