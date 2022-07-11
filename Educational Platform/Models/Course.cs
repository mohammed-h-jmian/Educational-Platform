namespace Educational_Platform.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public String CourseName { get; set; }
        public int  CourseHours { get; set; }
        public int CoursePrice { get; set; }

        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }

        public int TeacherId { get; set; }
        public int DepartmentId { get; set; }




        public virtual ICollection<StudentCourse> StudentCourse { get; set; }

    }
}
