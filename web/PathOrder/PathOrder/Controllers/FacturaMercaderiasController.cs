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
    public class FacturaMercaderiasController : Controller
    {
        private PathOrderEntities1 db = new PathOrderEntities1();

        // GET: FacturaMercaderias
        public ActionResult Index()
        {
            var facturaMercaderia = db.FacturaMercaderia.Include(f => f.Factura).Include(f => f.Mercaderia);
            return View(facturaMercaderia.ToList());
        }

        // GET: FacturaMercaderias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaMercaderia facturaMercaderia = db.FacturaMercaderia.Find(id);
            if (facturaMercaderia == null)
            {
                return HttpNotFound();
            }
            return View(facturaMercaderia);
        }

        // GET: FacturaMercaderias/Create
        public ActionResult Create()
        {
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "Descripcion");
            ViewBag.IdMercaderia = new SelectList(db.Mercaderia, "IdMercaderia", "Descripcion");
            return View();
        }

        // POST: FacturaMercaderias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFacturaMercaderia,IdMercaderia,IdFactura")] FacturaMercaderia facturaMercaderia)
        {
            if (ModelState.IsValid)
            {
                db.FacturaMercaderia.Add(facturaMercaderia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "Descripcion", facturaMercaderia.IdFactura);
            ViewBag.IdMercaderia = new SelectList(db.Mercaderia, "IdMercaderia", "Descripcion", facturaMercaderia.IdMercaderia);
            return View(facturaMercaderia);
        }

        // GET: FacturaMercaderias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaMercaderia facturaMercaderia = db.FacturaMercaderia.Find(id);
            if (facturaMercaderia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "Descripcion", facturaMercaderia.IdFactura);
            ViewBag.IdMercaderia = new SelectList(db.Mercaderia, "IdMercaderia", "Descripcion", facturaMercaderia.IdMercaderia);
            return View(facturaMercaderia);
        }

        // POST: FacturaMercaderias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFacturaMercaderia,IdMercaderia,IdFactura")] FacturaMercaderia facturaMercaderia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaMercaderia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFactura = new SelectList(db.Factura, "IdFactura", "Descripcion", facturaMercaderia.IdFactura);
            ViewBag.IdMercaderia = new SelectList(db.Mercaderia, "IdMercaderia", "Descripcion", facturaMercaderia.IdMercaderia);
            return View(facturaMercaderia);
        }

        // GET: FacturaMercaderias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaMercaderia facturaMercaderia = db.FacturaMercaderia.Find(id);
            if (facturaMercaderia == null)
            {
                return HttpNotFound();
            }
            return View(facturaMercaderia);
        }

        // POST: FacturaMercaderias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacturaMercaderia facturaMercaderia = db.FacturaMercaderia.Find(id);
            db.FacturaMercaderia.Remove(facturaMercaderia);
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
