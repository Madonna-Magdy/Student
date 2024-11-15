namespace Domains.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}