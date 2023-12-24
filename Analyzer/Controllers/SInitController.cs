﻿using Analyzer.Data;
using Analyzer.Models;
using Analyzer.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Analyzer.Controllers
{
    public class SInitController : Controller
    {
        [BindProperty]
        public StageInitVM StageVM { get; set; }

        private readonly ApplicationDbContext _db;
        public SInitController (ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Device> sList = _db.Device.Where(u=>u.Stage==Stages.Init);
            return View(sList);
        }
        public IActionResult Create(int id)
        {
            StageVM = new StageInitVM()
            {
                Device = _db.Device.Find(id),
                PartsList = _db.Component.Where(u => u.Type == ComponentType.Parts).ToList(),
                EvaluateList = _db.Component.Where(u => u.Type == ComponentType.Evaluate).ToList(),
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

            for (int i = 0; i < StageVM.AccessoriesList.Count(); i++)
            {
                if (StageVM.AccessoriesList[i].Visible)
                {
                    DeviceComponent deviceComponent = new DeviceComponent()
                    {
                        DeviceId = StageVM.Device.Id,
                        ComponentId = StageVM.AccessoriesList[i].Id,
                        Stage = Stages.Init
                    };
                    _db.DeviceComponent.Add(deviceComponent);
                }
                if (StageVM.EvaluateList[i].Visible)
                {
                    DeviceComponent deviceComponent = new DeviceComponent()
                    {
                        DeviceId = StageVM.Device.Id,
                        ComponentId = StageVM.EvaluateList[i].Id,
                        Stage = Stages.Init
                    };
                    _db.DeviceComponent.Add(deviceComponent);
                }
                if (StageVM.PartsList[i].Visible)
                {
                    DeviceComponent deviceComponent = new DeviceComponent()
                    {
                        DeviceId = StageVM.Device.Id,
                        ComponentId = StageVM.PartsList[i].Id,
                        Stage = Stages.Init
                    };
                    _db.DeviceComponent.Add(deviceComponent);
                }

                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0){
                return NotFound();
            }
            StageVM = new StageInitVM(); 
            StageVM.Device =_db.Device.Find(id);
            if (StageVM.Device == null)
            {
                return NotFound();
            }
            return View(StageVM);
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
            return View(StageVM);
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
    }
}
