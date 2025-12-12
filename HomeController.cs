using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using k_museum.Data;
using k_museum.Models;

namespace k_museum.Controllers
{
    public class HomeController : Controller
    {
        private readonly MuseumContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(MuseumContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // Просто берем первые 6 экспонатов (без IsFeatured)
            var featuredExhibits = await _context.Exhibits
                .Include(e => e.Author)
                .Include(e => e.Category)
                .Take(6)
                .ToListAsync();

            ViewBag.FeaturedExhibits = featuredExhibits;
            return View();
        }

        // Остальные методы остаются без изменений
        public IActionResult Exhibition() => View();
        public IActionResult Biography() => View();
        public IActionResult Admission() => View();
        public IActionResult Eshop() => View();
        public IActionResult Contacts() => View();
        public IActionResult Tickets() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}