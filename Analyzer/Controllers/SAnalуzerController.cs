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
        public IActionResult Create(int id)
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
        public IActionResult Create(StageAllVM StageEdVM)
        {
            if (!ModelState.IsValid)
            {
                StageVM.Device.Stage = Stages.Analyser;
                _db.Device.Update(StageVM.Device);
                for (int i = 0; i < StageEdVM.DevCompEvalList.Count; i++)
                {
                    StageEdVM.DevCompEvalList[i].Stage = Stages.Analyser;
                    _db.DeviceComponent.Update(StageEdVM.DevCompEvalList[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompAssList.Count; i++)
                {
                    StageEdVM.DevCompAssList[i].Stage = Stages.Analyser;
                    _db.DeviceComponent.Update(StageEdVM.DevCompAssList[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompPartsList.Count; i++)
                {
                    StageEdVM.DevCompPartsList[i].Stage = Stages.Analyser;
                    _db.DeviceComponent.Update(StageEdVM.DevCompPartsList[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompEval2List.Count; i++)
                {
                    StageEdVM.DevCompEval2List[i].Stage = Stages.Analyser2;
                    _db.DeviceComponent.Update(StageEdVM.DevCompEval2List[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompAss2List.Count; i++)
                {
                    StageEdVM.DevCompAss2List[i].Stage = Stages.Analyser2;
                    _db.DeviceComponent.Update(StageEdVM.DevCompAss2List[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompParts2List.Count; i++)
                {
                    StageEdVM.DevCompParts2List[i].Stage = Stages.Analyser2;
                    _db.DeviceComponent.Update(StageEdVM.DevCompParts2List[i]);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(StageVM);
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0) return NotFound();
            StageVM = new StageAllVM();
            StageVM.Device = _db.Device.Find(id);
            if (StageVM.Device == null) return NotFound();

            StageVM.CompList = _db.Component.ToList();
            StageVM.DevCompEvalList = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Analyser && u.Type == ComponentType.Evaluate).ToList();
            StageVM.DevCompPartsList = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Analyser && u.Type == ComponentType.Parts).ToList();
            StageVM.DevCompAssList = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Analyser && u.Type == ComponentType.Accessories).ToList();
            StageVM.DevCompEval2List = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Analyser2 && u.Type == ComponentType.Evaluate).ToList();
            StageVM.DevCompParts2List = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Analyser2 && u.Type == ComponentType.Parts).ToList();
            StageVM.DevCompAss2List = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Analyser2 && u.Type == ComponentType.Accessories).ToList();
            return View(StageVM);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StageAllVM StageEdVM)
        {
            if (!ModelState.IsValid)
            {
                StageVM.Device.Stage = Stages.Analyser;
                _db.Device.Update(StageVM.Device);
                for (int i = 0; i < StageEdVM.DevCompEvalList.Count; i++)
                {
                    StageEdVM.DevCompEvalList[i].Stage = Stages.Analyser;
                    _db.DeviceComponent.Update(StageEdVM.DevCompEvalList[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompAssList.Count; i++)
                {
                    StageEdVM.DevCompAssList[i].Stage = Stages.Analyser;
                    _db.DeviceComponent.Update(StageEdVM.DevCompAssList[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompPartsList.Count; i++)
                {
                    StageEdVM.DevCompPartsList[i].Stage = Stages.Analyser;
                    _db.DeviceComponent.Update(StageEdVM.DevCompPartsList[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompEval2List.Count; i++)
                {
                    StageEdVM.DevCompEval2List[i].Stage = Stages.Analyser2;
                    _db.DeviceComponent.Update(StageEdVM.DevCompEval2List[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompAss2List.Count; i++)
                {
                    StageEdVM.DevCompAss2List[i].Stage = Stages.Analyser2;
                    _db.DeviceComponent.Update(StageEdVM.DevCompAss2List[i]);
                }
                for (int i = 0; i < StageEdVM.DevCompParts2List.Count; i++)
                {
                    StageEdVM.DevCompParts2List[i].Stage = Stages.Analyser2;
                    _db.DeviceComponent.Update(StageEdVM.DevCompParts2List[i]);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(StageVM);
        }
    }
}
