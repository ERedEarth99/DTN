using Microsoft.AspNetCore.Mvc;
using DTN.Models;

namespace DTN.Controllers
{
    public class AlbumController : Controller
    {
        private readonly MusicAppDbContext _context;

        public AlbumController(MusicAppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var albums = _context.Albums.ToList();
            return View(albums);
        }

        public IActionResult Details(int id)
        {
            var album = _context.Albums.FirstOrDefault(a => a.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Albums.Add(album);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }
    }
}
