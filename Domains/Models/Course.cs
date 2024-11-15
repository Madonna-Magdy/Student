namespace Domains.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}