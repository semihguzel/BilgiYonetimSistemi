using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class SinavController : Controller
    {
        private Context db = new Context();

        // GET: Sinav
        public ActionResult Index()
        {
            return View(db.Sinavlar.ToList());
        }

        // GET: Sinav/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinav sinav = db.Sinavlar.Find(id);
            if (sinav == null)
            {
                return HttpNotFound();
            }
            return View(sinav);
        }

        // GET: Sinav/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sinav/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SinavID,SinavTipi")] Sinav sinav)
        {
            if (ModelState.IsValid)
            {
                db.Sinavlar.Add(sinav);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sinav);
        }

        // GET: Sinav/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinav sinav = db.Sinavlar.Find(id);
            if (sinav == null)
            {
                return HttpNotFound();
            }
            return View(sinav);
        }

        // POST: Sinav/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SinavID,SinavTipi")] Sinav sinav)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinav).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sinav);
        }

        // GET: Sinav/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinav sinav = db.Sinavlar.Find(id);
            if (sinav == null)
            {
                return HttpNotFound();
            }
            return View(sinav);
        }

        // POST: Sinav/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sinav sinav = db.Sinavlar.Find(id);
            db.Sinavlar.Remove(sinav);
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
