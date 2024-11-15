using Microsoft.EntityFrameworkCore;

namespace Domains.Models
{
    public partial class CourseContext : DbContext
    {
        public CourseContext()
        {
        }

        public CourseContext(DbContextOptions<CourseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.ToTable("StudentCourse");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.FkCourse)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.FkCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCourse_ToCourse");

                entity.HasOne(d => d.FkStudent)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.FkStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCourse_ToStudent");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}