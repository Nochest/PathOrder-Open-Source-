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
    public class MercaderiasController : Controller
    {
        private PathOrderEntities1 db = new PathOrderEntities1();

        // GET: Mercaderias
        public ActionResult Index()
        {
            return View(db.Mercaderia.ToList());
        }

        // GET: Mercaderias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercaderia mercaderia = db.Mercaderia.Find(id);
            if (mercaderia == null)
            {
                return HttpNotFound();
            }
            return View(mercaderia);
        }

        // GET: Mercaderias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mercaderias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMercaderia,Descripcion,Tipo")] Mercaderia mercaderia)
        {
            if (ModelState.IsValid)
            {
                db.Mercaderia.Add(mercaderia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mercaderia);
        }

        // GET: Mercaderias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercaderia mercaderia = db.Mercaderia.Find(id);
            if (mercaderia == null)
            {
                return HttpNotFound();
            }
            return View(mercaderia);
        }

        // POST: Mercaderias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMercaderia,Descripcion,Tipo")] Mercaderia mercaderia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mercaderia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mercaderia);
        }

        // GET: Mercaderias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mercaderia mercaderia = db.Mercaderia.Find(id);
            if (mercaderia == null)
            {
                return HttpNotFound();
            }
            return View(mercaderia);
        }

        // POST: Mercaderias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mercaderia mercaderia = db.Mercaderia.Find(id);
            db.Mercaderia.Remove(mercaderia);
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
