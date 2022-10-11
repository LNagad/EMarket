using EMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category()
        {
            return RedirectToRoute(new { controller = "Category", action = "Index" });
        }

    }
}