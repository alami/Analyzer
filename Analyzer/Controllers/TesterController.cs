using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    public class TesterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
