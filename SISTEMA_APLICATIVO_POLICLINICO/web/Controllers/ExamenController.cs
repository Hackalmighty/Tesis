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
    public class ExamenController : Controller
    {
        // GET: Examen
        private readonly IServicioExamenes _ServicioExamenes = Dependencia.GetInstance<IServicioExamenes>();

        public ActionResult Index()
        {
            return View(_ServicioExamenes.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Examen model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioExamenes.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = _ServicioExamenes.Get(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Examen model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioExamenes.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _ServicioExamenes.Delete(id);
            return View();
        }
    }
}
