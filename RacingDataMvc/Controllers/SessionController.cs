using Microsoft.AspNet.Identity;
using Racing.Model.Session;
using Racing.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RacingDataMvc.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            var service = CreateSessionService();
            var model = service.GetSession();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        // Test Convert.ToString(model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSessionService();

            if (service.CreateSession(model))
            {
                TempData["SaveResultSession"] = "Session Created";
                return RedirectToAction("Index");
                
            };
            ModelState.AddModelError("", "Session could not be created");
            return RedirectToAction(Convert.ToString(model));
        }
        public ActionResult SessionLapDetails(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionLap(id);

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateSessionService();
            var detail = service.GetSessionById(id);
            var model =
                new SessionEdit
                {
                    Track = detail.Track,
                };
            return View(model);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SessionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SessionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSessionService();

            if (service.UpdateSession(model))
            {
                TempData["SaveResultSession"] = "Session updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your session was not updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSessionService();

            service.DeleteSession(id);

            TempData["SaveResultSession"] = "Session Delete";

            return RedirectToAction("Index");
        }
        private SessionService CreateSessionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            return service;
        }
    }
}