using Educational_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace Educational_Platform.Data
{
    public class EducationalPlatformContext : DbContext
    {
        public EducationalPlatformContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(bc => new { bc.StudentID, bc.CourseID });
        }
    }
}