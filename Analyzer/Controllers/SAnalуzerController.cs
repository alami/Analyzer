using Analyzer.Data;
using Analyzer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    //[Authorize]
    public class SAnalуzerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SAnalуzerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Device> sList = _db.Device.Where(u=>u.Stage==Stages.Analyser);
            return View(sList);
        }
    }
}
