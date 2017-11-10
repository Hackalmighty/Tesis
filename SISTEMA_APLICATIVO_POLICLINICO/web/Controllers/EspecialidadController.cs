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
    public class EspecialidadController : Controller
    {
        private readonly IServicioEspecialidadMedicas _ServicioEspecialidadesMedicas = Dependencia.GetInstance<IServicioEspecialidadMedicas>();

        public ActionResult Index()
        {
            return View(_ServicioEspecialidadesMedicas.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EspecialidadMedica model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioEspecialidadesMedicas.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = _ServicioEspecialidadesMedicas.Get(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(EspecialidadMedica model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioEspecialidadesMedicas.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _ServicioEspecialidadesMedicas.Delete(id);
            return View();
        }

    }
}