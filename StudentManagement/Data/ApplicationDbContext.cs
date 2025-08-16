using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Alice", LastName = "Rahman", Email = "alice@example.com", Age = 17 },
                new Student { Id = 2, FirstName = "Tanvir", LastName = "Ahmed", Email = "tanvir@example.com", Age = 19 },
                new Student { Id = 3, FirstName = "Nusrat", LastName = "Jahan", Email = "nusrat@example.com", Age = 22 },
                new Student { Id = 4, FirstName = "Rafiul", LastName = "Islam", Email = "rafiul@example.com", Age = 18 },
                new Student { Id = 5, FirstName = "Mim", LastName = "Chowdhury", Email = "mim@example.com", Age = 25 }
            );
        }

    }
}
