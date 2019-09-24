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
    public class AgenteAduaneroesController : Controller
    {
        private PathOrderEntities1 db = new PathOrderEntities1();

        // GET: AgenteAduaneroes
        public ActionResult Index()
        {
            return View(db.AgenteAduanero.ToList());
        }

        // GET: AgenteAduaneroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteAduanero agenteAduanero = db.AgenteAduanero.Find(id);
            if (agenteAduanero == null)
            {
                return HttpNotFound();
            }
            return View(agenteAduanero);
        }

        // GET: AgenteAduaneroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgenteAduaneroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAgenteAduanero,Nombre,RUC,Nickname,Password,PermisoAdmin")] AgenteAduanero agenteAduanero)
        {
            if (ModelState.IsValid)
            {
                db.AgenteAduanero.Add(agenteAduanero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agenteAduanero);
        }

        // GET: AgenteAduaneroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteAduanero agenteAduanero = db.AgenteAduanero.Find(id);
            if (agenteAduanero == null)
            {
                return HttpNotFound();
            }
            return View(agenteAduanero);
        }

        // POST: AgenteAduaneroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAgenteAduanero,Nombre,RUC,Nickname,Password,PermisoAdmin")] AgenteAduanero agenteAduanero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenteAduanero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agenteAduanero);
        }

        // GET: AgenteAduaneroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteAduanero agenteAduanero = db.AgenteAduanero.Find(id);
            if (agenteAduanero == null)
            {
                return HttpNotFound();
            }
            return View(agenteAduanero);
        }

        // POST: AgenteAduaneroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgenteAduanero agenteAduanero = db.AgenteAduanero.Find(id);
            db.AgenteAduanero.Remove(agenteAduanero);
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
