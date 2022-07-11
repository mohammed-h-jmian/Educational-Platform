using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Educational_Platform.Data;
using Educational_Platform.Models;

namespace Educational_Platform.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly EducationalPlatformContext _context;

        public StudentCoursesController(EducationalPlatformContext context)
        {
            _context = context;
        }

        // GET: StudentCourses
        public async Task<IActionResult> Index()
        {
            var educationalPlatformContext = _context.StudentCourses.Include(s => s.Course).Include(s => s.Student);
            return View(await educationalPlatformContext.ToListAsync());
        }

        //public ActionResult CreateStudentCourses()
        //{
        //    //ViewBag.CourseID = new SelectList(_context.Courses, "CourseID", "CourseName");
        //    //ViewBag.StudentID = new SelectList(_context.Courses, "StudentID", "StudentName");
        //    //ViewBag.Students = _context.Students;
        //    //ViewBag.Courses = _context.Courses;

        //    return View();
        //}

        // GET: StudentCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentCourses == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public ActionResult Create()
        {

    //        ViewBag.CourseID = new SelectList(_context.Courses, "CourseID", "CourseName");
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "StudentName");
            ViewBag.Students = _context.Students;

            ViewBag.Courses = _context.Courses;

          //  ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
       //     ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID");
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //******************\\

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CourseID,StudentID")] StudentCourse studentCourse)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //        _context.Add(studentCourse);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    //}
        //    ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", studentCourse.CourseID);
        //    ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", studentCourse.StudentID);
        //    //return View(studentCourse);
        //    return RedirectToAction("Index");
        //}

        //******************\\
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int StudentID, int[] courseIds)
        {

            ViewBag.CourseID = new SelectList(_context.Courses, "CourseID", "CourseName");
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "StudentName");
            ViewBag.Students = _context.Students;
            ViewBag.Courses = _context.Courses;

            foreach (int crcID in courseIds)
            {
                StudentCourse stdCourse = new StudentCourse();
                stdCourse.StudentID = StudentID;
                stdCourse.CourseID = crcID;
                _context.StudentCourses.Add(stdCourse);
                _context.SaveChanges();

            }

            return RedirectToAction("Index");

        }

        //****************\\

        // GET: StudentCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentCourses == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", studentCourse.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", studentCourse.StudentID);
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,StudentID")] StudentCourse studentCourse)
        {
            if (id != studentCourse.StudentID)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(studentCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseExists(studentCourse.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", studentCourse.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", studentCourse.StudentID);
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public async Task<IActionResult> Delete(int? studentId, int courseId)
        {
            if ((studentId == null && courseId == null) || _context.StudentCourses == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => (m.StudentID == studentId && m.CourseID == courseId));
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int studentId, int courseId)
        {
            if (_context.StudentCourses == null)
                {
                return Problem("Entity set 'EducationalPlatformContext.StudentCourses'  is null.");
            }
            var studentCourse = await _context.StudentCourses.SingleOrDefaultAsync(x=>x.CourseID == courseId && x.StudentID == studentId);
            if (studentCourse != null)
            {
                _context.StudentCourses.Remove(studentCourse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
          return (_context.StudentCourses?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
