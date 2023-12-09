using Analyzer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    [Authorize]
    public class AnalyzerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AnalyzerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
