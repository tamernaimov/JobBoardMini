
using JobBoardMini.Data;
using JobBoardMini.Library;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardMini.Web.Controllers
{
    public class InternshipsController : Controller
    {
        private readonly JobBoardDbContext _db;

        public InternshipsController(JobBoardDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var internships = _db.Internships.ToList();

            return View(internships);
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

            _db.Internships.Add(internship);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
