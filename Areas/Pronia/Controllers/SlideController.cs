using Microsoft.AspNetCore.Mvc;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Pronia.Controllers
{
    public class SlideController : Controller
    {
        public AppDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slide slide)
        {
            if (slide.Image is null)
            {
                ModelState.AddModelError("Image", "Sekil secin");
                return View();
            }
          

            if (slide.Image.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Image", "2mb olsun");
                return View();
            }
            FileStream file = new FileStream(@"C:\Users\Azer\Desktop\ProniaWebApplication\wwwroot\assets\images\slider\" + slide.Image.FileName, FileMode.Create);
            await slide.Image.CopyToAsync(file);

            slide.Image = slide.Image.FileName;

            await _context.Sliders.AddAsync(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return BadRequest();
            var slide = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);
            if (slide is null) return NotFound();

            return View(slide);
        }
    }

}

