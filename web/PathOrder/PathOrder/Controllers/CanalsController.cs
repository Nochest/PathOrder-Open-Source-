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
    public class CanalsController : Controller
    {
        private PathOrderEntities1 db = new PathOrderEntities1();

        // GET: Canals
        public ActionResult Index()
        {
            return View(db.Canal.ToList());
        }

        // GET: Canals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canal canal = db.Canal.Find(id);
            if (canal == null)
            {
                return HttpNotFound();
            }
            return View(canal);
        }

        // GET: Canals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Canals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCanal,Nombre,Descripcion")] Canal canal)
        {
            if (ModelState.IsValid)
            {
                db.Canal.Add(canal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(canal);
        }

        // GET: Canals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canal canal = db.Canal.Find(id);
            if (canal == null)
            {
                return HttpNotFound();
            }
            return View(canal);
        }

        // POST: Canals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCanal,Nombre,Descripcion")] Canal canal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(canal);
        }

        // GET: Canals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canal canal = db.Canal.Find(id);
            if (canal == null)
            {
                return HttpNotFound();
            }
            return View(canal);
        }

        // POST: Canals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Canal canal = db.Canal.Find(id);
            db.Canal.Remove(canal);
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
