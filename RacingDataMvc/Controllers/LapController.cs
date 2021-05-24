using Microsoft.AspNet.Identity;
using Racing.Model.Laps;
using Racing.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RacingDataMvc.Controllers
{
    public class LapController : Controller
    {
        // GET: Lap
        public ActionResult Index()
        {
            var service = CreateLapService();
            var model = service.GetLap();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LapCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLapService();

            if (service.CreateLap(model))
            {
                TempData["SaveResultLap"] = "Lap Created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Lap could not be created");
            return RedirectToAction(Convert.ToString(model));
        }
        public ActionResult Details(int id)
        {
            var svc = CreateLapService();
            var model = svc.GetSessionLaps(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateLapService();
            var detail = service.GetLapById(id);
            var model =
                new LapEdit
                {
                    SessionId = detail.SessionId,
                    LapMinutes = detail.LapMinutes,
                    LapSeconds = detail.LapSeconds,
                    LapTenthSeconds = detail.LapTenthSeconds,
                    LapHundrethSeconds = detail.LapHundrethSeconds,
                    LapMilliseconds = detail.LapMilliseconds,
                    SectorOneMinutes = detail.SectorOneMinutes,
                    SectorOneSeconds = detail.SectorOneSeconds,
                    SectorOneTenthSeconds = detail.SectorOneTenthSeconds,
                    SectorOneHundrethSeconds = detail.SectorOneHundrethSeconds,
                    SectorOneMilliseconds = detail.SectorOneMilliseconds,
                    SectorTwoMinutes = detail.SectorTwoMinutes,
                    SectorTwoSeconds = detail.SectorTwoSeconds,
                    SectorTwoTenthSeconds = detail.SectorTwoTenthSeconds,
                    SectorTwoHundrethSeconds = detail.SectorTwoHundrethSeconds,
                    SectorTwoMilliseconds = detail.SectorTwoMilliseconds,
                    SectorThreeMinutes = detail.SectorThreeMinutes,
                    SectorThreeSeconds = detail.SectorThreeSeconds,
                    SectorThreeTenthSeconds = detail.SectorThreeTenthSeconds,
                    SectorThreeHundrethSeconds = detail.SectorThreeHundrethSeconds,
                    SectorThreeMilliseconds = detail.SectorThreeMilliseconds,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LapEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LapId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLapService();

            if (service.UpdateLap(model))
            {
                TempData["SaveResultLap"] = "Lap updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your vehicle was not updated");
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLapService();

            service.DeleteLap(id);

            TempData["SaveResultLap"] = "Lap Delete";

            return RedirectToAction("Index");
        }
        private LapService CreateLapService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LapService(userId);
            return service;
        }
    }
}