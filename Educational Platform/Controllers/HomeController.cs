using Educational_Platform.Data;
using Educational_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Educational_Platform.Controllers
{
    public class HomeController : Controller
    {


        private readonly EducationalPlatformContext _context;
        public HomeController(EducationalPlatformContext context)
        {
            _context = context;
        }
        

        public IActionResult Index()
        {
            var inrerface = new InterfaceViewModel();
            inrerface.studenCount = _context.Students.Count();
            inrerface.teacherCount = _context.Teachers.Count();
            inrerface.courseCount = _context.Courses.Count();
            inrerface.DepartCount = _context.Departments.Count();
            ViewBag.studentCount = inrerface.studenCount;
            ViewBag.teacherCount = inrerface.teacherCount;
            ViewBag.courseCount = inrerface.courseCount;
            ViewBag.DepartCount = inrerface.DepartCount;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}