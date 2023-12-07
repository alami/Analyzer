using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
