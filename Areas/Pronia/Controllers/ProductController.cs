using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Pronia.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public IActionResult Index()
        {
            return View();
        }
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
    }
}
