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
    public class OgretmenBilgileriController : Controller
    {
        private Context db = new Context();

        // GET: OgretmenBilgileri
        public ActionResult Index()
        {
            var ogretmenBilgileri = db.OgretmenBilgileri.Include(o => o.BilgininOgretmeni);
            return View(ogretmenBilgileri.ToList());
        }

        // GET: OgretmenBilgileri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenBilgileri ogretmenBilgileri = db.OgretmenBilgileri.Find(id);
            if (ogretmenBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(ogretmenBilgileri);
        }

        // GET: OgretmenBilgileri/Create
        public ActionResult Create()
        {
            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi");
            return View();
        }

        // POST: OgretmenBilgileri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgretmenID,TCNo,OgretmenMail,Fotograf")] OgretmenBilgileri ogretmenBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.OgretmenBilgileri.Add(ogretmenBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi", ogretmenBilgileri.OgretmenID);
            return View(ogretmenBilgileri);
        }

        // GET: OgretmenBilgileri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenBilgileri ogretmenBilgileri = db.OgretmenBilgileri.Find(id);
            if (ogretmenBilgileri == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi", ogretmenBilgileri.OgretmenID);
            return View(ogretmenBilgileri);
        }

        // POST: OgretmenBilgileri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgretmenID,TCNo,OgretmenMail,Fotograf")] OgretmenBilgileri ogretmenBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretmenBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi", ogretmenBilgileri.OgretmenID);
            return View(ogretmenBilgileri);
        }

        // GET: OgretmenBilgileri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenBilgileri ogretmenBilgileri = db.OgretmenBilgileri.Find(id);
            if (ogretmenBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(ogretmenBilgileri);
        }

        // POST: OgretmenBilgileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgretmenBilgileri ogretmenBilgileri = db.OgretmenBilgileri.Find(id);
            db.OgretmenBilgileri.Remove(ogretmenBilgileri);
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
