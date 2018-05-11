using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Domain.Entitee;

namespace Historisation.Controllers
{
    public class PauseController : Controller
    {
        IPauseService service ;
        IEmployeService service1;
        public PauseController()
        {
            service = new PauseService();
            service1 = new EmployeService();
        }
        // GET: Pause
        public ActionResult Index()
        {
            Session["h_d"] = DateTime.Now;
            return View();
        }

        // GET: Pause/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pause/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pause/Create
        [HttpPost]
        public ActionResult Create(Pause paus)
        {
            string login = (string)(Session["login"]);
            Employe emp = service1.getByLogout(login);
            DateTime h_d = (DateTime)(Session["h_d"]);
            DateTime h_f = DateTime.Now;
            TimeSpan diff1 = h_f.Subtract(h_d);
            string duree = diff1.Hours + "  Heures  " + diff1.Minutes + "  Minutes " + diff1.Seconds + " Secondes";
            try
            {
                Pause pause = new Pause();
                pause.type=paus.type;
                pause.debut= h_d;
                pause.fin = h_f;
                pause.duree = duree;
                pause.EmployeID = emp.EmployeID;
                service.Add(pause);
                service.SaveChange();
                return RedirectToAction("Acceuil","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pause/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pause/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pause/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pause/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
