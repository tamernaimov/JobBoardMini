using JobBoardMini.Web.ViewModels.Internships;
using JobBoardMini.Library;
using JobBoardMini.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardMini.Web.Controllers
{
    public class InternshipsController : Controller
    {
        private readonly IInternshipService _internshipService;

        public InternshipsController(IInternshipService internshipService)
        {
            _internshipService = internshipService;
        }

        public IActionResult Index()
        {
            var viewModel = new InternshipsIndexViewModel
            {
                Internships = _internshipService.GetAll()
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Internship internship)
        {
            if (!ModelState.IsValid)
            {
                return View(internship);
            }

            _internshipService.Add(internship);

            return RedirectToAction(nameof(Index));
        }
    }
}
