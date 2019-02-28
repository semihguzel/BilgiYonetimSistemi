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
    public class OgrencilerDerslerDonemlerController : Controller
    {
        private Context db = new Context();

        // GET: OgrencilerDerslerDonemler
        public ActionResult Index()
        {
            var ogrencilerDersler = db.OgrencilerDersler.Include(o => o.DersinOgrencisi).Include(o => o.OgrenciDersinDonemi).Include(o => o.OgrencininDersi);
            return View(ogrencilerDersler.ToList());
        }

        // GET: OgrencilerDerslerDonemler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrencilerDerslerDonemler ogrencilerDerslerDonemler = db.OgrencilerDersler.Find(id);
            if (ogrencilerDerslerDonemler == null)
            {
                return HttpNotFound();
            }
            return View(ogrencilerDerslerDonemler);
        }

        // GET: OgrencilerDerslerDonemler/Create
        public ActionResult Create()
        {
            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi");
            ViewBag.DonemID = new SelectList(db.Donemler, "DonemID", "DonemYili");
            ViewBag.DersID = new SelectList(db.Dersler, "DersID", "DersAdi");
            return View();
        }

        // POST: OgrencilerDerslerDonemler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrenciDerslerDonemler,OgrenciID,DersID,DonemID")] OgrencilerDerslerDonemler ogrencilerDerslerDonemler)
        {
            if (ModelState.IsValid)
            {
                db.OgrencilerDersler.Add(ogrencilerDerslerDonemler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi", ogrencilerDerslerDonemler.OgrenciID);
            ViewBag.DonemID = new SelectList(db.Donemler, "DonemID", "DonemYili", ogrencilerDerslerDonemler.DonemID);
            ViewBag.DersID = new SelectList(db.Dersler, "DersID", "DersAdi", ogrencilerDerslerDonemler.DersID);
            return View(ogrencilerDerslerDonemler);
        }

        // GET: OgrencilerDerslerDonemler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrencilerDerslerDonemler ogrencilerDerslerDonemler = db.OgrencilerDersler.Find(id);
            if (ogrencilerDerslerDonemler == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi", ogrencilerDerslerDonemler.OgrenciID);
            ViewBag.DonemID = new SelectList(db.Donemler, "DonemID", "DonemYili", ogrencilerDerslerDonemler.DonemID);
            ViewBag.DersID = new SelectList(db.Dersler, "DersID", "DersAdi", ogrencilerDerslerDonemler.DersID);
            return View(ogrencilerDerslerDonemler);
        }

        // POST: OgrencilerDerslerDonemler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrenciDerslerDonemler,OgrenciID,DersID,DonemID")] OgrencilerDerslerDonemler ogrencilerDerslerDonemler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrencilerDerslerDonemler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi", ogrencilerDerslerDonemler.OgrenciID);
            ViewBag.DonemID = new SelectList(db.Donemler, "DonemID", "DonemYili", ogrencilerDerslerDonemler.DonemID);
            ViewBag.DersID = new SelectList(db.Dersler, "DersID", "DersAdi", ogrencilerDerslerDonemler.DersID);
            return View(ogrencilerDerslerDonemler);
        }

        // GET: OgrencilerDerslerDonemler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrencilerDerslerDonemler ogrencilerDerslerDonemler = db.OgrencilerDersler.Find(id);
            if (ogrencilerDerslerDonemler == null)
            {
                return HttpNotFound();
            }
            return View(ogrencilerDerslerDonemler);
        }

        // POST: OgrencilerDerslerDonemler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgrencilerDerslerDonemler ogrencilerDerslerDonemler = db.OgrencilerDersler.Find(id);
            db.OgrencilerDersler.Remove(ogrencilerDerslerDonemler);
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
