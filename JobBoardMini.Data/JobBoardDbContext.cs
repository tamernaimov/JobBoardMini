
using JobBoardMini.Library;
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
    }
}
