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
    public class TipoExamenOcupacionalController : Controller
    {
        private readonly IServicioTipoExamenOcupacionales _ServicioTipoExamenOcupacional = Dependencia.GetInstance<IServicioTipoExamenOcupacionales>();

        public ActionResult Index()
        {
            return View(_ServicioTipoExamenOcupacional.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TipoExamenOcupacional model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioTipoExamenOcupacional.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = _ServicioTipoExamenOcupacional.Get(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(TipoExamenOcupacional model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioTipoExamenOcupacional.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _ServicioTipoExamenOcupacional.Delete(id);
            return View();
        }

    }
}