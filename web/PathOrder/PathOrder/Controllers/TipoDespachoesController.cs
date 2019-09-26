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
    public class TipoDespachoesController : Controller
    {
        private PathOrderEntities1 db = new PathOrderEntities1();

        // GET: TipoDespachoes
        public ActionResult Index()
        {
            return View(db.TipoDespacho.ToList());
        }

        // GET: TipoDespachoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDespacho tipoDespacho = db.TipoDespacho.Find(id);
            if (tipoDespacho == null)
            {
                return HttpNotFound();
            }
            return View(tipoDespacho);
        }

        // GET: TipoDespachoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDespachoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoDespacho,Nombre")] TipoDespacho tipoDespacho)
        {
            if (ModelState.IsValid)
            {
                db.TipoDespacho.Add(tipoDespacho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDespacho);
        }

        // GET: TipoDespachoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDespacho tipoDespacho = db.TipoDespacho.Find(id);
            if (tipoDespacho == null)
            {
                return HttpNotFound();
            }
            return View(tipoDespacho);
        }

        // POST: TipoDespachoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoDespacho,Nombre")] TipoDespacho tipoDespacho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDespacho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDespacho);
        }

        // GET: TipoDespachoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDespacho tipoDespacho = db.TipoDespacho.Find(id);
            if (tipoDespacho == null)
            {
                return HttpNotFound();
            }
            return View(tipoDespacho);
        }

        // POST: TipoDespachoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDespacho tipoDespacho = db.TipoDespacho.Find(id);
            db.TipoDespacho.Remove(tipoDespacho);
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
