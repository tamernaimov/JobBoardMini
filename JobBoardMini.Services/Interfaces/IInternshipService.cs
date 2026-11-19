using JobBoardMini.Library;
using JobBoardMini.Services.DTOs.Internships;

namespace JobBoardMini.Services.Interfaces
{
    public interface IInternshipService
    {
        List<InternshipListDto> GetAll();
        void Add(Internship internship);
    }
}