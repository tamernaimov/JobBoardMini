using JobBoardMini.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardMini.Data
{
    public class JobBoardDbContext : DbContext
    {
        public JobBoardDbContext(DbContextOptions<JobBoardDbContext> options)
            : base(options)
        {
        }

        public DbSet<Internship> Internships { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}