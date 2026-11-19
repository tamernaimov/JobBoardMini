using JobBoardMini.Data;
using JobBoardMini.Library;
using JobBoardMini.Services.DTOs.Internships;
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

        public List<InternshipListDto> GetAll()
        {
            return _db.Internships
                .Select(i => new InternshipListDto
                {
                    Id = i.Id,
                    Position = i.Position,
                    Organization = i.Organization,
                    City = i.City,
                    DurationWeeks = i.DurationWeeks,
                    Description = i.Description
                })
                .ToList();
        }

        public void Add(Internship internship)
        {
            _db.Internships.Add(internship);
            _db.SaveChanges();
        }
    }
}