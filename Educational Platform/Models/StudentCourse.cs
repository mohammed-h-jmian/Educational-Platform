using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.Models
{
    //public enum Grade
    //{
    //    A, B, C, D, F
    //}
    public class StudentCourse
    {

        
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        //      [DisplayFormat(NullDisplayText = "No grade")]
        //    public Grade? Grade { get; set; }
        //      public Course Course { get; set; }
        //       public Student Student { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
