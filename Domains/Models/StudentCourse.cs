namespace Domains.Models
{
    public partial class StudentCourse
    {
        public int Id { get; set; }
        public int FkCourseId { get; set; }
        public int FkStudentId { get; set; }
        public double Score { get; set; }

        public virtual Course FkCourse { get; set; }
        public virtual Student FkStudent { get; set; }
    }
}