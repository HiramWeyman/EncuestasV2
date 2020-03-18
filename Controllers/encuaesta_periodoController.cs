using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EncuestasV2.Models;
using EncuestasV2.Filters;


namespace EncuestasV2.Controllers
{
    [AccederAdmin]
    public class encuaesta_periodoController : Controller
    {
        private csstdura_encuestaEntities db = new csstdura_encuestaEntities();

        // GET: encuaesta_periodo
        public ActionResult Index()
        {
            return View(db.encuaesta_periodo.ToList());
        }

        // GET: encuaesta_periodo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            encuaesta_periodo encuaesta_periodo = db.encuaesta_periodo.Find(id);
            if (encuaesta_periodo == null)
            {
                return HttpNotFound();
            }
            return View(encuaesta_periodo);
        }

        // GET: encuaesta_periodo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: encuaesta_periodo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "periodo_id,periodo_desc,periodo_estatus")] encuaesta_periodo encuaesta_periodo)
        {
            if (ModelState.IsValid)
            {
                db.encuaesta_periodo.Add(encuaesta_periodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encuaesta_periodo);
        }

        // GET: encuaesta_periodo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            encuaesta_periodo encuaesta_periodo = db.encuaesta_periodo.Find(id);
            if (encuaesta_periodo == null)
            {
                return HttpNotFound();
            }
            return View(encuaesta_periodo);
        }

        // POST: encuaesta_periodo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "periodo_id,periodo_desc,periodo_estatus")] encuaesta_periodo encuaesta_periodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encuaesta_periodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encuaesta_periodo);
        }

        // GET: encuaesta_periodo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            encuaesta_periodo encuaesta_periodo = db.encuaesta_periodo.Find(id);
            if (encuaesta_periodo == null)
            {
                return HttpNotFound();
            }
            return View(encuaesta_periodo);
        }

        // POST: encuaesta_periodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            encuaesta_periodo encuaesta_periodo = db.encuaesta_periodo.Find(id);
            db.encuaesta_periodo.Remove(encuaesta_periodo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
