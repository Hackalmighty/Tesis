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
    public class EmpresaController : Controller
    {
        private readonly IServicioEmpresas _ServicioEmpresas = Dependencia.GetInstance<IServicioEmpresas>();

        public ActionResult Index()
        {
            return View(_ServicioEmpresas.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Empresa model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioEmpresas.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = _ServicioEmpresas.Get(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Empresa model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioEmpresas.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _ServicioEmpresas.Delete(id);
            return View();
        }
    }
}
