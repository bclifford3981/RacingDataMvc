using Microsoft.AspNet.Identity;
using Racing.Model;
using Racing.Model.Vehicle;
using Racing.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RacingDataMvc.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        public ActionResult Index()
        {
            var service = CreateVehicleService();
            var model = service.GetVehicle();
            return View(model);
        }
        // GET: Vehicle
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateVehicleService();

            if (service.CreateVehicle(model))
            {
                TempData["SaveResult"] = "Vehicle Created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Vehicle could not be created");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateVehicleService();
            var model = svc.GetVehicleById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateVehicleService();
            var detail = service.GetVehicleById(id);
            var model =
                new VehicleEdit
                {
                    VehicleId = detail.VehicleId,
                    Name = detail.Name,
                    Class = detail.Class,
                    Series = detail.Series,
                    HP = detail.HP,
                    Weight = detail.Weight
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VehicleId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateVehicleService();

            if (service.UpdateVehicle(model))
            {
                TempData["SaveResult"] = "Vehicle updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your vehicle was not updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateVehicleService();
            var model = svc.GetVehicleById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVehicleService();

            service.DeleteVehicle(id);

            TempData["SaveResult"] = "Vehicle Delete";

            return RedirectToAction("Index");
        }

        private VehicleService CreateVehicleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VehicleService(userId);
            return service;
        }
    }
}