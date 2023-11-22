using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApplication.Areas.Pronia.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
