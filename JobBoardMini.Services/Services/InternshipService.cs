
using JobBoardMini.Data;
using JobBoardMini.Library;
using JobBoardMini.Services.Interfaces;

namespace JobBoardMini.Services.Services
{
    public class InternshipService : IInternshipService
    {
        private readonly JobBoardDbContext _db;

        public InternshipService(JobBoardDbContext db)
        {
            _db = db;
        }

        public List<Internship> GetAll()
        {
            return _db.Internships.ToList();
        }

        public void Add(Internship internship)
        {
            _db.Internships.Add(internship);
            _db.SaveChanges();
        }
    }
}
