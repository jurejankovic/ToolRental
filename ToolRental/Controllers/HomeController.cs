using Microsoft.AspNetCore.Mvc;

namespace ToolRental.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
