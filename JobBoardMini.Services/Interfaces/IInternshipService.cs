using JobBoardMini.Data.Models;
using JobBoardMini.Services.DTOs.Internships;

namespace JobBoardMini.Services.Interfaces
{
    public interface IInternshipService
    {
        List<InternshipListDto> GetAll();
        List<Company> GetCompanies();
        List<Category> GetCategories();
        void Add(Internship internship);
    }
}