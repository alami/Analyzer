using Analyzer.Data;
using Analyzer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers;

public class SCalculateController : Controller
{
    private readonly ApplicationDbContext _db;
    public SCalculateController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        IEnumerable<Device> sList = _db.Device.Where(u=>u.Stage==Stages.Result);
        return View(sList);    
    }
}