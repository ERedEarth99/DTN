using DTN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DTN.Controllers
{
    public class SongsController : Controller
    {
        private readonly MusicAppDbContext _context;

        public SongsController(MusicAppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var songs = _context.Songs.Include(s => s.Artist).Include(s => s.Album).Include(s => s.Genre).ToList();
            return View(songs);
        }

        public IActionResult Details(int id)
        {
            var song = _context.Songs.Include(s => s.Artist).Include(s => s.Album).Include(s => s.Genre).FirstOrDefault(s => s.SongId == id);
            if (song == null) return NotFound();

            return View(song);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Songs.Add(song);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }
    }
}