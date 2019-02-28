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
    public class OgretmenlerBolumlerController : Controller
    {
        private Context db = new Context();

        // GET: OgretmenlerBolumler
        public ActionResult Index()
        {
            var ogretmenlerBolumler = db.OgretmenlerBolumler.Include(o => o.BolumunOgretmeni).Include(o => o.OgretmeninBolumu);
            return View(ogretmenlerBolumler.ToList());
        }

        // GET: OgretmenlerBolumler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenlerBolumler ogretmenlerBolumler = db.OgretmenlerBolumler.Find(id);
            if (ogretmenlerBolumler == null)
            {
                return HttpNotFound();
            }
            return View(ogretmenlerBolumler);
        }

        // GET: OgretmenlerBolumler/Create
        public ActionResult Create()
        {
            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi");
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi");
            return View();
        }

        // POST: OgretmenlerBolumler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgretmenlerBolumlerID,OgretmenID,BolumID")] OgretmenlerBolumler ogretmenlerBolumler)
        {
            if (ModelState.IsValid)
            {
                db.OgretmenlerBolumler.Add(ogretmenlerBolumler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi", ogretmenlerBolumler.OgretmenID);
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi", ogretmenlerBolumler.BolumID);
            return View(ogretmenlerBolumler);
        }

        // GET: OgretmenlerBolumler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenlerBolumler ogretmenlerBolumler = db.OgretmenlerBolumler.Find(id);
            if (ogretmenlerBolumler == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi", ogretmenlerBolumler.OgretmenID);
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi", ogretmenlerBolumler.BolumID);
            return View(ogretmenlerBolumler);
        }

        // POST: OgretmenlerBolumler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgretmenlerBolumlerID,OgretmenID,BolumID")] OgretmenlerBolumler ogretmenlerBolumler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretmenlerBolumler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgretmenID = new SelectList(db.Ogretmenler, "OgretmenID", "OgretmenAdi", ogretmenlerBolumler.OgretmenID);
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi", ogretmenlerBolumler.BolumID);
            return View(ogretmenlerBolumler);
        }

        // GET: OgretmenlerBolumler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgretmenlerBolumler ogretmenlerBolumler = db.OgretmenlerBolumler.Find(id);
            if (ogretmenlerBolumler == null)
            {
                return HttpNotFound();
            }
            return View(ogretmenlerBolumler);
        }

        // POST: OgretmenlerBolumler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgretmenlerBolumler ogretmenlerBolumler = db.OgretmenlerBolumler.Find(id);
            db.OgretmenlerBolumler.Remove(ogretmenlerBolumler);
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
