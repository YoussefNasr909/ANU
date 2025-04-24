using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ANU.Models;

namespace AssiutUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index(int? facultyId = null)
        {
            //DB
            var departments = new List<Department>
            {
                new Department
                {
                    Id = 1,
                    Name = "Computer Science",
                    Description = "The Computer Science department focuses on algorithms, programming languages, and software development.",
                    FacultyId = 1
                },
                new Department
                {
                    Id = 2,
                    Name = "Information Systems",
                    Description = "The Information Systems department focuses on database management, system analysis, and information technology infrastructure.",
                    FacultyId = 1
                },
                new Department
                {
                    Id = 3,
                    Name = "Artificial Intelligence",
                    Description = "The Artificial Intelligence department focuses on machine learning, neural networks, and intelligent systems.",
                    FacultyId = 1
                },
                new Department
                {
                    Id = 4,
                    Name = "Internal Medicine",
                    Description = "The Internal Medicine department focuses on the diagnosis and treatment of adult diseases.",
                    FacultyId = 2
                },
                new Department
                {
                    Id = 5,
                    Name = "Surgery",
                    Description = "The Surgery department focuses on surgical procedures and techniques.",
                    FacultyId = 2
                }
            };

            
            if (facultyId.HasValue)
            {
                departments = departments.Where(d => d.FacultyId == facultyId.Value).ToList();
                
                ViewBag.FacultyName = facultyId == 1 ? "Faculty of Computers & Artificial Intelligence" :
                                     facultyId == 2 ? "Faculty of Medicine" :
                                     "Faculty of Engineering & Applied Sciences";
            }
            else
            {
                ViewBag.FacultyName = "All Faculties";
            }

            return View(departments);
        }

        public IActionResult Details(int id)
        {
            // This would typically come from a database
            var department = new Department
            {
                Id = id,
                Name = "Computer Science",
                Description = "The Computer Science department focuses on algorithms, programming languages, and software development.",
                FacultyId = 1
            };

            return View(department);
        }
    }
}
