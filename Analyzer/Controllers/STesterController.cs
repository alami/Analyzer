using Analyzer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    //[Authorize]
    public class STesterController : Controller
    {
        private readonly ApplicationDbContext _db;
        public STesterController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
