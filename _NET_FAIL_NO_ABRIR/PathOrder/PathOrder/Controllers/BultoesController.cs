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
    public class BultoesController : Controller
    {
        private PathOrderEntities1 db = new PathOrderEntities1();

        // GET: Bultoes
        public ActionResult Index()
        {
            var bulto = db.Bulto.Include(b => b.OrdenDespacho);
            return View(bulto.ToList());
        }

        // GET: Bultoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulto bulto = db.Bulto.Find(id);
            if (bulto == null)
            {
                return HttpNotFound();
            }
            return View(bulto);
        }

        // GET: Bultoes/Create
        public ActionResult Create()
        {
            ViewBag.IdOrdenDespacho = new SelectList(db.OrdenDespacho, "IdOrdenDespacho", "Prioridad");
            return View();
        }

        // POST: Bultoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBulto,Peso,IdOrdenDespacho")] Bulto bulto)
        {
            if (ModelState.IsValid)
            {
                db.Bulto.Add(bulto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOrdenDespacho = new SelectList(db.OrdenDespacho, "IdOrdenDespacho", "Prioridad", bulto.IdOrdenDespacho);
            return View(bulto);
        }

        // GET: Bultoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulto bulto = db.Bulto.Find(id);
            if (bulto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOrdenDespacho = new SelectList(db.OrdenDespacho, "IdOrdenDespacho", "Prioridad", bulto.IdOrdenDespacho);
            return View(bulto);
        }

        // POST: Bultoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBulto,Peso,IdOrdenDespacho")] Bulto bulto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bulto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdOrdenDespacho = new SelectList(db.OrdenDespacho, "IdOrdenDespacho", "Prioridad", bulto.IdOrdenDespacho);
            return View(bulto);
        }

        // GET: Bultoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulto bulto = db.Bulto.Find(id);
            if (bulto == null)
            {
                return HttpNotFound();
            }
            return View(bulto);
        }

        // POST: Bultoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bulto bulto = db.Bulto.Find(id);
            db.Bulto.Remove(bulto);
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
