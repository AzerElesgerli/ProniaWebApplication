using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Pronia.Controllers
{
    public class TagController : Controller
    {
        public AppDbContext _context;
        
        public async Task<IActionResult> Index()
        {
            List<Tag> tags = await _context.//.Include(t => t.ProductTags).ToListAsync();
            return View(tags);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (!ModelState.IsValid) return View();

            bool result = _context.//.Any(c => c.Name.ToLower().Trim() == tag.Name.ToLower().Trim());
            if (result)
            {
                ModelState.AddModelError("Name", "Bu Tag artiq movcuddur.");
                return View();
            }
            await _context.//.AddAsync(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }
}
