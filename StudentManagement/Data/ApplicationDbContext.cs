using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> StudentResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    StudentName = "Alice Rahman",
                    CourseTitle = "Mathematics",
                    TotalMarks = 45,
                    Status = Status.NeedsImprovement
                },
                new Student
                {
                    Id = 2,
                    StudentName = "Tanvir Ahmed",
                    CourseTitle = "Physics",
                    TotalMarks = 75,
                    Status = Status.Good
                },
                new Student
                {
                    Id = 3,
                    StudentName = "Nusrat Jahan",
                    CourseTitle = "English",
                    TotalMarks = 85,
                    Status = Status.Excellent
                },
                new Student
                {
                    Id = 4,
                    StudentName = "Rafiul Islam",
                    CourseTitle = "Chemistry",
                    TotalMarks = 68,
                    Status = Status.Good
                },
                new Student
                {
                    Id = 5,
                    StudentName = "Mim Chowdhury",
                    CourseTitle = "Biology",
                    TotalMarks = 88,
                    Status = Status.Excellent
                },
                new Student
                {
                    Id = 6,
                    StudentName = "Mehedi Hasan",
                    CourseTitle = "History",
                    TotalMarks = 33,
                    Status = Status.NeedsImprovement
                }
            );
        }

    }
}
