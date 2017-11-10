using Common;
using Model.Dominio;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IServicioMedicos _ServicioMedicos = Dependencia.GetInstance<IServicioMedicos>();

        // GET: Medico
        public ActionResult Index()
        {
            return View(_ServicioMedicos.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Medico model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioMedicos.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = _ServicioMedicos.Get(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Medico model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioMedicos.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _ServicioMedicos.Delete(id);
            return View();
        }

    }
}