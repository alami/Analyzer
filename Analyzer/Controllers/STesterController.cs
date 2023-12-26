using Analyzer.Data;
using Analyzer.Models;
using Analyzer.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    //[Authorize]
    public class STesterController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public StageInitVM StageVM { get; set; }

        [BindProperty]
        public StageEditVM StageEdVM { get; set; }
        public STesterController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Device> sList = _db.Device.Where(u => u.Stage == Stages.Tester);
            return View(sList);
        }
        public IActionResult Create(int id)
        {
            StageVM = new StageInitVM()
            {
                Device = _db.Device.Find(id),
                EvaluateList = _db.Component.Where(u => u.Type == ComponentType.Evaluate).ToList(),
                PartsList = _db.Component.Where(u => u.Type == ComponentType.Parts).ToList(),
                AccessoriesList = _db.Component.Where(u => u.Type == ComponentType.Accessories).ToList(),
            };
            return View(StageVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Create(StageInitVM StageVM)
        {
            /*Device d = _db.Device.Find(id);
            IEnumerable <DeviceComponent>  dc = _db.DeviceComponent.Where(u=>u.DeviceId == id);
            StageInitVM stageVM1 = stageVM;*/
            StageVM.Device.Stage = Stages.Tester;           
            _db.Device.Update(StageVM.Device);

            for (int i = 0; i < StageVM.EvaluateList.Count(); i++)
            {
                if (StageVM.EvaluateList[i].Visible)
                {
                    DeviceComponent deviceComponent = new DeviceComponent()
                    {
                        DeviceId = StageVM.Device.Id,
                        ComponentId = StageVM.EvaluateList[i].Id,
                        Type = StageVM.EvaluateList[i].Type,
                        Stage = Stages.Tester
                    };
                    _db.DeviceComponent.Add(deviceComponent);
                }
            }
            for (int i = 0; i < StageVM.AccessoriesList.Count(); i++)
            {
                if (StageVM.AccessoriesList[i].Visible)
                {
                    DeviceComponent deviceComponent = new DeviceComponent()
                    {
                        DeviceId = StageVM.Device.Id,
                        ComponentId = StageVM.AccessoriesList[i].Id,
                        Type = StageVM.AccessoriesList[i].Type,
                        Stage = Stages.Tester
                    };
                    _db.DeviceComponent.Add(deviceComponent);
                }
            }
            for (int i = 0; i < StageVM.PartsList.Count(); i++)
            {
                if (StageVM.PartsList[i].Visible)
                {
                    DeviceComponent deviceComponent = new DeviceComponent()
                    {
                        DeviceId = StageVM.Device.Id,
                        ComponentId = StageVM.PartsList[i].Id,
                        Type = StageVM.PartsList[i].Type,
                        Stage = Stages.Tester
                    };
                    _db.DeviceComponent.Add(deviceComponent);
                }
            }
            _db.SaveChanges();   
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            StageEdVM = new StageEditVM();
            StageEdVM.Device = _db.Device.Find(id);
            if (StageEdVM.Device == null) return NotFound();

            StageEdVM.CompList = _db.Component.ToList();
            StageEdVM.DevCompEvalList = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Tester && u.Type == ComponentType.Evaluate).ToList();
            StageEdVM.DevCompPartsList = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Tester && u.Type == ComponentType.Parts).ToList();
            StageEdVM.DevCompAssList = _db.DeviceComponent.Where(u => u.DeviceId == id && u.Stage == Stages.Tester && u.Type == ComponentType.Accessories).ToList();
            return View(StageEdVM);
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
