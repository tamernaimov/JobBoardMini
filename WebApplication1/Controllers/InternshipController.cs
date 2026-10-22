using JobBoardMini.Library.JobBoardMini.Library;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardMini.Web.Controllers
{
    public class InternshipsController : Controller
    {
        private static readonly List<Internship> internships = new()
        {
            new Internship
            {
                Id = 1,
                Position = "Стажант програмист",
                Organization = "Tech Company",
                City = "София",
                DurationWeeks = 4,
                Description = "Работа по уеб приложения."
            },
            new Internship
            {
                Id = 2,
                Position = "Уеб дизайнер",
                Organization = "Creative Studio",
                City = "Пловдив",
                DurationWeeks = 6,
                Description = "Създаване на дизайн за уеб сайтове."
            },
            new Internship
            {
                Id = 3,
                Position = "QA стажант",
                Organization = "Software Team",
                City = "София",
                DurationWeeks = 3,
                Description = "Тестване на софтуер."
            }
        };

        public IActionResult Index(string? position, string? city)
        {
            var result = internships.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(position))
            {
                result = result.Where(i =>
                    i.Position.Contains(position,
                        StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                result = result.Where(i =>
                    i.City.Contains(city,
                        StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.Position = position;
            ViewBag.City = city;
            

            return View(result.ToList());
        }

        [HttpGet]
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

            internship.Id = internships.Count == 0
                ? 1
                : internships.Max(i => i.Id) + 1;

            internships.Add(internship);

            return RedirectToAction(nameof(Index));
        }
    }
}
