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
    public class OgrencilerBolumlerController : Controller
    {
        private Context db = new Context();

        // GET: OgrencilerBolumler
        public ActionResult Index()
        {
            var ogrencilerBolumler = db.OgrencilerBolumler.Include(o => o.BolumunOgrencisi).Include(o => o.OgrencininBolumu);
            return View(ogrencilerBolumler.ToList());
        }

        // GET: OgrencilerBolumler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrencilerBolumler ogrencilerBolumler = db.OgrencilerBolumler.Find(id);
            if (ogrencilerBolumler == null)
            {
                return HttpNotFound();
            }
            return View(ogrencilerBolumler);
        }

        // GET: OgrencilerBolumler/Create
        public ActionResult Create()
        {
            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi");
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi");
            return View();
        }

        // POST: OgrencilerBolumler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrencilerBolumlerID,OgrenciID,BolumID")] OgrencilerBolumler ogrencilerBolumler)
        {
            if (ModelState.IsValid)
            {
                db.OgrencilerBolumler.Add(ogrencilerBolumler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi", ogrencilerBolumler.OgrenciID);
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi", ogrencilerBolumler.BolumID);
            return View(ogrencilerBolumler);
        }

        // GET: OgrencilerBolumler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrencilerBolumler ogrencilerBolumler = db.OgrencilerBolumler.Find(id);
            if (ogrencilerBolumler == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi", ogrencilerBolumler.OgrenciID);
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi", ogrencilerBolumler.BolumID);
            return View(ogrencilerBolumler);
        }

        // POST: OgrencilerBolumler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrencilerBolumlerID,OgrenciID,BolumID")] OgrencilerBolumler ogrencilerBolumler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrencilerBolumler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi", ogrencilerBolumler.OgrenciID);
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi", ogrencilerBolumler.BolumID);
            return View(ogrencilerBolumler);
        }

        // GET: OgrencilerBolumler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrencilerBolumler ogrencilerBolumler = db.OgrencilerBolumler.Find(id);
            if (ogrencilerBolumler == null)
            {
                return HttpNotFound();
            }
            return View(ogrencilerBolumler);
        }

        // POST: OgrencilerBolumler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgrencilerBolumler ogrencilerBolumler = db.OgrencilerBolumler.Find(id);
            db.OgrencilerBolumler.Remove(ogrencilerBolumler);
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
