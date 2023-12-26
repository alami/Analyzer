using Analyzer.Data;
using Analyzer.Models;
using Analyzer.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    //[Authorize]
    public class SAnalуzerController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public StageAllVM StageVM { get; set; }
        public SAnalуzerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Device> sList = _db.Device.Where(u=>u.Stage==Stages.Analyser);
            return View(sList);
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0) return NotFound();
            StageVM = new StageAllVM();
            StageVM.Device = _db.Device.Find(id);
            if (StageVM.Device == null) return NotFound();

            StageVM.CompList = _db.Component.ToList();
            StageVM.DevCompEvalList = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Init && u.Type == ComponentType.Evaluate).ToList();
            StageVM.DevCompPartsList = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Init && u.Type == ComponentType.Parts).ToList();
            StageVM.DevCompAssList = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Init && u.Type == ComponentType.Accessories).ToList();
            StageVM.DevCompEval2List = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Tester && u.Type == ComponentType.Evaluate).ToList();
            StageVM.DevCompParts2List = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Tester && u.Type == ComponentType.Parts).ToList();
            StageVM.DevCompAss2List = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Tester && u.Type == ComponentType.Accessories).ToList();
            return View(StageVM);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StageEditVM StageEdVM)
        {
            if (!ModelState.IsValid)
            {
                for (int i = 0; i < StageEdVM.DevCompEvalList.Count; i++)
                    _db.DeviceComponent.Update(StageEdVM.DevCompEvalList[i]);
                for (int i = 0; i < StageEdVM.DevCompAssList.Count; i++)
                    _db.DeviceComponent.Update(StageEdVM.DevCompAssList[i]);
                for (int i = 0; i < StageEdVM.DevCompPartsList.Count; i++)
                    _db.DeviceComponent.Update(StageEdVM.DevCompPartsList[i]);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(StageVM);
        }
    }
}
