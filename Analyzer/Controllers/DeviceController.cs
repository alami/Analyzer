using Analyzer.Data;
using Analyzer.Models;
using Analyzer.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Analyzer.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public StageInitVM StageVM {  get; set; }
        public DeviceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Device> objList = _db.Device;
            return View(objList);
        }
        //GET Create
        public IActionResult Create()
        {
            return View();
        }
        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Device obj)
        {
            if (ModelState.IsValid)
            {
                _db.Device.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0){
                return NotFound();
            }
            var obj=_db.Device.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Device obj)
        {
            if (ModelState.IsValid)
            {
                _db.Device.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0){
                return NotFound();
            }
            var obj=_db.Device.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Device.Find(id);
            if (obj==null) {
                return NotFound();
            }
            _db.Device.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult StageInit(int id)
        {
            StageVM = new StageInitVM() {
                Device = _db.Device.Find(id),
                PartsList = _db.Component.Where(u=>u.Type == ComponentType.Parts).ToList(),
                EvaluateList = _db.Component.Where(u=>u.Type == ComponentType.Evaluate).ToList(),
                AccessoriesList = _db.Component.Where(u=>u.Type == ComponentType.Accessories).ToList(),                
            };
            return View(StageVM);
        }
        [HttpPost, ActionName("StageInit")]
        [ValidateAntiForgeryToken]
        public IActionResult StageInitPost(StageInitVM StageVM)
        {
            /*Device d = _db.Device.Find(id);
            IEnumerable <DeviceComponent>  dc = _db.DeviceComponent.Where(u=>u.DeviceId == id);
            StageInitVM stageVM1 = stageVM;*/

            return RedirectToAction ("Index");
        }
    }
}
