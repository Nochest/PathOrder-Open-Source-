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
    public class DAMsController : Controller
    {
        private PathOrderEntities1 db = new PathOrderEntities1();

        // GET: DAMs
        public ActionResult Index()
        {
            return View(db.DAM.ToList());
        }

        // GET: DAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAM dAM = db.DAM.Find(id);
            if (dAM == null)
            {
                return HttpNotFound();
            }
            return View(dAM);
        }

        // GET: DAMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DAMs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDAM,Descripcion,CIF")] DAM dAM)
        {
            if (ModelState.IsValid)
            {
                db.DAM.Add(dAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dAM);
        }

        // GET: DAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAM dAM = db.DAM.Find(id);
            if (dAM == null)
            {
                return HttpNotFound();
            }
            return View(dAM);
        }

        // POST: DAMs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDAM,Descripcion,CIF")] DAM dAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dAM);
        }

        // GET: DAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAM dAM = db.DAM.Find(id);
            if (dAM == null)
            {
                return HttpNotFound();
            }
            return View(dAM);
        }

        // POST: DAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DAM dAM = db.DAM.Find(id);
            db.DAM.Remove(dAM);
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
