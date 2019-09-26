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
    public class OrdenDespachoesController : Controller
    {
        private PathOrderEntities1 db = new PathOrderEntities1();

        // GET: OrdenDespachoes
        public ActionResult Index()
        {
            var ordenDespacho = db.OrdenDespacho.Include(o => o.AgenteAduanero).Include(o => o.Canal).Include(o => o.DAM).Include(o => o.Fecha).Include(o => o.Proveedor).Include(o => o.TipoDespacho);
            return View(ordenDespacho.ToList());
        }

        // GET: OrdenDespachoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDespacho ordenDespacho = db.OrdenDespacho.Find(id);
            if (ordenDespacho == null)
            {
                return HttpNotFound();
            }
            return View(ordenDespacho);
        }

        // GET: OrdenDespachoes/Create
        public ActionResult Create()
        {
            ViewBag.IdAgenteAduanero = new SelectList(db.AgenteAduanero, "IdAgenteAduanero", "Nombre");
            ViewBag.IdCanal = new SelectList(db.Canal, "IdCanal", "Nombre");
            ViewBag.IdDAM = new SelectList(db.DAM, "IdDAM", "Descripcion");
            ViewBag.IdFecha = new SelectList(db.Fecha, "IdFecha", "IdFecha");
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre");
            ViewBag.IdTipoDespacho = new SelectList(db.TipoDespacho, "IdTipoDespacho", "Nombre");
            return View();
        }

        // POST: OrdenDespachoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdOrdenDespacho,NumeroOrden,Prioridad,AWB_BL,AWB_BLOrigen,Origen,CantidadSeries,CantidadBultos,IdTipoDespacho,IdDAM,IdProveedor,IdCanal,IdFecha,Observacion,IdAgenteAduanero")] OrdenDespacho ordenDespacho)
        {
            if (ModelState.IsValid)
            {
                db.OrdenDespacho.Add(ordenDespacho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAgenteAduanero = new SelectList(db.AgenteAduanero, "IdAgenteAduanero", "Nombre", ordenDespacho.IdAgenteAduanero);
            ViewBag.IdCanal = new SelectList(db.Canal, "IdCanal", "Nombre", ordenDespacho.IdCanal);
            ViewBag.IdDAM = new SelectList(db.DAM, "IdDAM", "Descripcion", ordenDespacho.IdDAM);
            ViewBag.IdFecha = new SelectList(db.Fecha, "IdFecha", "IdFecha", ordenDespacho.IdFecha);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", ordenDespacho.IdProveedor);
            ViewBag.IdTipoDespacho = new SelectList(db.TipoDespacho, "IdTipoDespacho", "Nombre", ordenDespacho.IdTipoDespacho);
            return View(ordenDespacho);
        }

        // GET: OrdenDespachoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDespacho ordenDespacho = db.OrdenDespacho.Find(id);
            if (ordenDespacho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAgenteAduanero = new SelectList(db.AgenteAduanero, "IdAgenteAduanero", "Nombre", ordenDespacho.IdAgenteAduanero);
            ViewBag.IdCanal = new SelectList(db.Canal, "IdCanal", "Nombre", ordenDespacho.IdCanal);
            ViewBag.IdDAM = new SelectList(db.DAM, "IdDAM", "Descripcion", ordenDespacho.IdDAM);
            ViewBag.IdFecha = new SelectList(db.Fecha, "IdFecha", "IdFecha", ordenDespacho.IdFecha);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", ordenDespacho.IdProveedor);
            ViewBag.IdTipoDespacho = new SelectList(db.TipoDespacho, "IdTipoDespacho", "Nombre", ordenDespacho.IdTipoDespacho);
            return View(ordenDespacho);
        }

        // POST: OrdenDespachoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdOrdenDespacho,NumeroOrden,Prioridad,AWB_BL,AWB_BLOrigen,Origen,CantidadSeries,CantidadBultos,IdTipoDespacho,IdDAM,IdProveedor,IdCanal,IdFecha,Observacion,IdAgenteAduanero")] OrdenDespacho ordenDespacho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenDespacho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAgenteAduanero = new SelectList(db.AgenteAduanero, "IdAgenteAduanero", "Nombre", ordenDespacho.IdAgenteAduanero);
            ViewBag.IdCanal = new SelectList(db.Canal, "IdCanal", "Nombre", ordenDespacho.IdCanal);
            ViewBag.IdDAM = new SelectList(db.DAM, "IdDAM", "Descripcion", ordenDespacho.IdDAM);
            ViewBag.IdFecha = new SelectList(db.Fecha, "IdFecha", "IdFecha", ordenDespacho.IdFecha);
            ViewBag.IdProveedor = new SelectList(db.Proveedor, "IdProveedor", "Nombre", ordenDespacho.IdProveedor);
            ViewBag.IdTipoDespacho = new SelectList(db.TipoDespacho, "IdTipoDespacho", "Nombre", ordenDespacho.IdTipoDespacho);
            return View(ordenDespacho);
        }

        // GET: OrdenDespachoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDespacho ordenDespacho = db.OrdenDespacho.Find(id);
            if (ordenDespacho == null)
            {
                return HttpNotFound();
            }
            return View(ordenDespacho);
        }

        // POST: OrdenDespachoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenDespacho ordenDespacho = db.OrdenDespacho.Find(id);
            db.OrdenDespacho.Remove(ordenDespacho);
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
