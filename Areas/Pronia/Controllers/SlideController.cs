using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Pronia.Controllers
{
    public class SlideController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SlideController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slide> Sliders = await _context.Slides.ToListAsync();
            return View(Sliders);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slide slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }





            slider.Image = slider.Image.CreateFile(_env.WebRootPath, "uploads/slide");

            await _context.Slides.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Slide slide = await _context.Slides.FirstOrDefaultAsync(x => x.Id == id);

            if (slide is null) return NotFound();

            return View(slide);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Slide slide)
        {
            Slide exist = await _context.Slides.FirstOrDefaultAsync(x => x.Id == id);

            if (exist is null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(exist);
            }

            if (slide.Image is not null)
            {

                if (!slide.Image.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Photo can be must image type");
                    return View();
                }

                if (slide.Image.CheckFileLength(300))
                {
                    ModelState.AddModelError("Photo", "Photo can not be than " + 300 + " kb");
                    return View();
                }

                exist.Image.DeleteFile(_env.WebRootPath, "uploads/slider");

                exist.Image = slide.Image.CreateFile(_env.WebRootPath, "uploads/slider");
            }

            exist.Name1 = slide.Name1;
            exist.Name2 = slide.Name2;
            exist.Description = slide.Description;
            exist.Order = slide.Order;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            Slide slide = await _context.Slides.FirstOrDefaultAsync(x => x.Id == id);

            if (slide is null) return NotFound();

            slide.Image.DeleteFile(_env.WebRootPath, "uploads/slider");



            _context.Slides.Remove(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}