using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Pronia.Controllers
{
    public class ColorController : Controller
    {
        public AppDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            bool result = await _context.Colors.AnyAsync(x => x.Name == color.Name);

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (result)
            {
                ModelState.AddModelError("Fullname", "Eyni adli yazici yarana bilmez");
                return View();
            }

            await _context.AddAsync(color);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Color color = await _context.Colors.FirstOrDefaultAsync(x => x.Id == id);

            if (color == null) return NotFound();

            return View(color);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Color color)
        {
            Color exist = await _context.Colors.FirstOrDefaultAsync(x => x.Id == id);

            if (exist == null) return NotFound();

            bool result = await _context.Colors.AnyAsync(x => x.Name == color.Name);

            if (!ModelState.IsValid)
            {
                return View(exist);
            }

            if (result)
            {
                ModelState.AddModelError("Color", "Eyni adli Reng yarana bilmez");
                return View(exist);
            }

            exist.Name = color.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Color exist = await _context.Colors.FirstOrDefaultAsync(x => x.Id == id);

            if (exist == null) return NotFound();

            _context.Colors.Remove(exist);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
    

