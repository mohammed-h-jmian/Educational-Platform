namespace Educational_Platform.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public DateTime StudentDateOfBirth { get; set; }
        public int StudentGender { get; set; }
        public String StudentAddress { get; set; }
        public int StudentPhone { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
