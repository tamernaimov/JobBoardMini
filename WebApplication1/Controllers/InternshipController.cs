using JobBoardMini.Data.Models;
using JobBoardMini.Services.Interfaces;
using JobBoardMini.Web.ViewModels.Internships;
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
            var viewModel = new InternshipCreateViewModel
            {
                Companies = _internshipService.GetCompanies(),
                Categories = _internshipService.GetCategories()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InternshipCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Companies = _internshipService.GetCompanies();
                viewModel.Categories = _internshipService.GetCategories();

                return View(viewModel);
            }

            _internshipService.Add(viewModel.Internship);

            return RedirectToAction(nameof(Index));
        }
    }
}