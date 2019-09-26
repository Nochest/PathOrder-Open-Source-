using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PathOrder.Models;

namespace PathOrder.Controllers
{
    public class FechasController : Controller
    {
        private PathOrderEntities1 db = new PathOrderEntities1();

        // GET: Fechas
        public ActionResult Index()
        {
            return View(db.Fecha.ToList());
        }

        // GET: Fechas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha fecha = db.Fecha.Find(id);
            if (fecha == null)
            {
                return HttpNotFound();
            }
            return View(fecha);
        }

        // GET: Fechas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fechas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFecha,FechaEnumeracion,FechaRetiro,FechaCancelacion,FechaLevante,FechaPrecosteo,KMMP")] Fecha fecha)
        {
            if (ModelState.IsValid)
            {
                db.Fecha.Add(fecha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fecha);
        }

        // GET: Fechas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha fecha = db.Fecha.Find(id);
            if (fecha == null)
            {
                return HttpNotFound();
            }
            return View(fecha);
        }

        // POST: Fechas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFecha,FechaEnumeracion,FechaRetiro,FechaCancelacion,FechaLevante,FechaPrecosteo,KMMP")] Fecha fecha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fecha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fecha);
        }

        // GET: Fechas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha fecha = db.Fecha.Find(id);
            if (fecha == null)
            {
                return HttpNotFound();
            }
            return View(fecha);
        }

        // POST: Fechas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fecha fecha = db.Fecha.Find(id);
            db.Fecha.Remove(fecha);
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
