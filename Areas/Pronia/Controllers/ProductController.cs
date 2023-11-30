using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.Areas.Pronia.ViewModels.Product;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Pronia.Controllers
{
	[Area("Pronia")]

	public class ProductController:Controller
	{

		private readonly AppDbContext _context;

		public ProductController(AppDbContext context)
		{
			_context = context;
		}

		#region Index
		public async Task<IActionResult> Index()
		{
			List<Product> Products = await _context.Products

				.Include(x => x.Name)
				.Include(x => x.Price)
				.Include(x => x.Image)
				.ToListAsync();

			return View(Products);
		}
		#endregion

		#region Create
		public async Task<IActionResult> Create()
		{
			CreateProductVM productCreateVM = new CreateProductVM();

			productCreateVM.Title = await _context.Name.ToListAsync();
			productCreateVM.Price = await _context.Price.ToListAsync();
			productCreateVM.Image = await _context.Image.ToListAsync();

			return View(productCreateVM);

		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductVM productCreateVM)
		{


			Product product = new Product()
			{
				Name = productCreateVM.Name,


				Price = (int?)productCreateVM.Price;
				
		
				 
			};

			



			await _context.Products.AddAsync(Product);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));

		
		#endregion



	}
}
