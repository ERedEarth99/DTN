using Microsoft.AspNetCore.Mvc;
using DTN.Models;

namespace DTN.Controllers
{
    public class ForumsController : Controller
    {
        private readonly MusicAppDbContext _context;

        public ForumsController(MusicAppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var forums = _context.Forums.ToList();
            return View(forums);
        }

        public IActionResult Details(int id)
        {
            var forum = _context.Forums.FirstOrDefault(f => f.ForumId == id);
            if (forum == null) return NotFound();
            return View(forum);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Forum forum)
        {
            if (ModelState.IsValid)
            {
                _context.Forums.Add(forum);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(forum);
        }
    }
}
