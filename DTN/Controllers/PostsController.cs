using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTN.Models;

namespace DTN.Controllers
{
    public class PostController : Controller
    {
        private readonly MusicAppDbContext _context;

        public PostController(MusicAppDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var post = _context.Posts
                               .Include(p => p.Comments)
                               .FirstOrDefault(p => p.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        public IActionResult Create(int forumId)
        {
            var post = new Post { ForumId = forumId };
            return View(post);
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Details", "Forums", new { id = post.ForumId });
            }
            return View(post);
        }
    }
}
