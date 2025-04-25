using Microsoft.EntityFrameworkCore;
using ANU.Models;

namespace ANU.Data
{
    // This is the main database context class that will be used to interact with the database
    // It inherits from DbContext which is the primary class for database interactions in Entity Framework Core
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for each entity that should be stored in the database
        // Each DbSet represents a table in the database
        public DbSet<Faculty> Faculties { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<AcademicProgram> Programs { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Staff> Staff { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Result> Results { get; set; } = null!;
        public DbSet<NewsItem> NewsItems { get; set; } = null!;
        public DbSet<BlogPost> BlogPosts { get; set; } = null!;

        // Override OnModelCreating to configure entity relationships, constraints, and seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships between entities
            // Example: Configure one-to-many relationship between Faculty and Department
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Faculty)
                .WithMany()
                .HasForeignKey(d => d.FacultyId);

            // Example: Configure one-to-many relationship between Faculty and AcademicProgram
            modelBuilder.Entity<AcademicProgram>()
                .HasOne<Faculty>()
                .WithMany(f => f.Programs)
                .HasForeignKey("FacultyId");

            // Add seed data
            // Example: Seed initial faculties
            modelBuilder.Entity<Faculty>().HasData(
                new Faculty
                {
                    Id = 1,
                    Name = "Faculty of Computers & Artificial Intelligence",
                    Description = "We believe that software and information technology is the future, hence we have recruited our knowledge in the fields of information system and automation mechanisms to serve our beliefs."
                },
                new Faculty
                {
                    Id = 2,
                    Name = "Faculty of Medicine",
                    Description = "Faculty of Medicine at Assiut University stands out as a leading establishment for medical education in Upper Egypt"
                },
                new Faculty
                {
                    Id = 3,
                    Name = "Faculty of Engineering & Applied Sciences",
                    Description = "63 years of experience and excellence in Engineering academic fields including Electrical Engineering, Civil Engineering, Mechanical Engineering, Architectural Engineering, and Mining and Metallurgical Engineering"
                }
            );
        }
    }
}
