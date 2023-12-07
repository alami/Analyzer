using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    public class AnalyzerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
