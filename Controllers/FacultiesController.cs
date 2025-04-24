using Microsoft.AspNetCore.Mvc;
using ANU.Models;
using System.Collections.Generic;


namespace AssiutUniversity.Controllers
{
    public class FacultiesController : Controller
    {
        public IActionResult Index()
        {
            // This would typically come from a database
            var faculties = new List<Faculty>
            {
                new Faculty
                {
                    Id = 1,
                    Name = "Faculty of Computers & Artificial Intelligence",
                    Description = "We believe that software and information technology is the future, hence we have recruited our knowledge in the fields of information system and automation mechanisms to serve our beliefs."
                },
                new Faculty
                {
                    Id = 2,
                    Name = "Faculty of Medicine",
                    Description = "Faculty of Medicine at Assiut University stands out as a leading establishment for medical education in Upper Egypt"
                },
                new Faculty
                {
                    Id = 3,
                    Name = "Faculty of Engineering & Applied Sciences",
                    Description = "63 years of experience and excellence in Engineering academic fields including Electrical Engineering, Civil Engineering, Mechanical Engineering, Architectural Engineering, and Mining and Metallurgical Engineering"
                }
            };

            return View(faculties);
        }

        public IActionResult Details(int id)
        {
            // This would typically come from a database
            var faculty = new Faculty
            {
                Id = id,
                Name = "Faculty of Computers & Artificial Intelligence",
                Description = "We believe that software and information technology is the future, hence we have recruited our knowledge in the fields of information system and automation mechanisms to serve our beliefs.",
                FullDescription = "The Faculty of Computers & Artificial Intelligence at Assiut National University is dedicated to providing cutting-edge education in computer science, information technology, and artificial intelligence. Our programs are designed to prepare students for the rapidly evolving tech industry.",
                ImageUrl = "/css/anu/faculty-computers.jpg",
                Programs = new List<Program>
                {
                    new Program { Id = 1, Name = "Computer Science" },
                    new Program { Id = 2, Name = "Information Systems" },
                    new Program { Id = 3, Name = "Artificial Intelligence" }
                }
            };

            return View(faculty);
        }
    }
}
