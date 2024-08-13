using Microsoft.EntityFrameworkCore;
using testsignar.Models;

namespace testsignar.Data
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
    }
}
