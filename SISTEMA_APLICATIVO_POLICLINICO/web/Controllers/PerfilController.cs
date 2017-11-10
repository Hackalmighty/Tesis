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
    public class PerfilController : Controller
    {
        private readonly IServicioPerfiles _ServicioPerfiles = Dependencia.GetInstance<IServicioPerfiles>();

        // GET: Perfil
        public ActionResult Index()
        {
            return View(_ServicioPerfiles.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Perfil model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioPerfiles.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = _ServicioPerfiles.Get(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Perfil model)
        {
            if (ModelState.IsValid)
            {
                var rh = _ServicioPerfiles.InsertOrUpdate(model);
                if (rh.Response)
                {
                    return RedirectToAction("index");
                }
            }

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _ServicioPerfiles.Delete(id);
            return View();
        }

    }
}