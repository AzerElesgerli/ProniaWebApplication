using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Pronia.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

      
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            bool result = await _context.Products.AnyAsync(x => x.Name == product.Name);

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (result)
            {
                ModelState.AddModelError("Name", "Eyni adli Product yaratmag olmaz");
                return View();
            }

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0) return BadRequest();

            Category category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (category is null) return NotFound();
            return View(category);

        }

    }
}
