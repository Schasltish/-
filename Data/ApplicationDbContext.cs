using Microsoft.EntityFrameworkCore;
using TestingProlect.Models;

namespace TestingProlect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<TestResult> TestResults { get; set; }
    }
}
