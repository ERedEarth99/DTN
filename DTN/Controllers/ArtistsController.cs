using Microsoft.AspNetCore.Mvc;
using DTN.Models;

namespace DTN.Controllers
{
    public class ArtistController : Controller
    {
        private readonly MusicAppDbContext _context;

        public ArtistController(MusicAppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var artists = _context.Artists.ToList();
            return View(artists);
        }

        public IActionResult Details(int id)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.ArtistId == id);
            if (artist == null) return NotFound();
            return View(artist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Artists.Add(artist);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }
    }
}
