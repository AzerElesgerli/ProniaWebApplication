using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;
using ProniaWebApplication.ViewModels;
using System.Diagnostics;

namespace ProniaWebApplication.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;


        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slide> Sliders = _context.Sliders.OrderBy(x => x.Order).ToList();
            List<Product> Products = _context.Products.ToList();

            HomeVM homeVM = new HomeVM
            {
                Sliders = Sliders,
                Products = Products,
            };
            return View(homeVM);
        }
    }
}