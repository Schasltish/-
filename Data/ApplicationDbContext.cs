using Microsoft.EntityFrameworkCore;
using TestingProject.Models;

namespace TestingProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<TestResult> TestResults { get; set; }
    }
}