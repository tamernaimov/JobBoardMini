
using JobBoardMini.Library;

namespace JobBoardMini.Services.Interfaces
{
    public interface IInternshipService
    {
        List<Internship> GetAll();

        void Add(Internship internship);
    }
}
