using Analyzer.Models.VM;
using Analyzer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Analyzer.Data;
using System.Linq;

namespace Analyzer.Controllers
{
    public class StageController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public StageDevCompVM StageVM { get; set; }
        public StageController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: StageController
        public ActionResult Index()
        {
            IEnumerable <Device> devices = _db.Device;

            return View(devices);

        }

        // GET: StageController/Details/5
        public ActionResult StageInit(int id)
        {
            Component c;
            List <Component> l = new List<Component> ();
            List<DeviceComponent> dc = _db.DeviceComponent.Where(u => (u.DeviceId == id && u.Stage == Stage.Init)).OrderBy(u=>u.ComponentId).ToList();
            foreach (var item in dc)
            {
                c = _db.Component.Find(item.ComponentId);
                l.Add(new Component()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Comment = c.Comment,
                    Price = c.Price,
                    Visible = true,
                    Pos = c.Pos,
                });  
            }
            StageVM = new StageDevCompVM()
            {
                Stage = Stage.Init,
                Device = _db.Device.Find(id),
                DevCompList = dc,
                EvaluateList = l,
                PartsList = null,
                AccessoriesList = null,
        };
            

            return View(StageVM);
        }

        // GET: StageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
