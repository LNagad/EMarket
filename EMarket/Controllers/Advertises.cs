using Microsoft.AspNetCore.Mvc;

namespace EMarket.Controllers
{
    public class Advertises : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
