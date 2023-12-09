using Analyzer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    [Authorize]
    public class TesterController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TesterController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
