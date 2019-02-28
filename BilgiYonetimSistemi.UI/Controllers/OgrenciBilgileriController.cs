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
    public class OgrenciBilgileriController : Controller
    {
        private Context db = new Context();

        // GET: OgrenciBilgileri
        public ActionResult Index()
        {
            var ogrenciBilgileri = db.OgrenciBilgileri.Include(o => o.BilgininOgrencisi);
            return View(ogrenciBilgileri.ToList());
        }

        // GET: OgrenciBilgileri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciBilgileri ogrenciBilgileri = db.OgrenciBilgileri.Find(id);
            if (ogrenciBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciBilgileri);
        }

        // GET: OgrenciBilgileri/Create
        public ActionResult Create()
        {
            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi");
            return View();
        }

        // POST: OgrenciBilgileri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrenciID,Adres,Telefon,TCNo,OgrenciMail,MezunMu,Fotograf,Sifre")] OgrenciBilgileri ogrenciBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.OgrenciBilgileri.Add(ogrenciBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi", ogrenciBilgileri.OgrenciID);
            return View(ogrenciBilgileri);
        }

        // GET: OgrenciBilgileri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciBilgileri ogrenciBilgileri = db.OgrenciBilgileri.Find(id);
            if (ogrenciBilgileri == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi", ogrenciBilgileri.OgrenciID);
            return View(ogrenciBilgileri);
        }

        // POST: OgrenciBilgileri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrenciID,Adres,Telefon,TCNo,OgrenciMail,MezunMu,Fotograf,Sifre")] OgrenciBilgileri ogrenciBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenciBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgrenciID = new SelectList(db.Ogrenciler, "OgrenciID", "OgrenciAdi", ogrenciBilgileri.OgrenciID);
            return View(ogrenciBilgileri);
        }

        // GET: OgrenciBilgileri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciBilgileri ogrenciBilgileri = db.OgrenciBilgileri.Find(id);
            if (ogrenciBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciBilgileri);
        }

        // POST: OgrenciBilgileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgrenciBilgileri ogrenciBilgileri = db.OgrenciBilgileri.Find(id);
            db.OgrenciBilgileri.Remove(ogrenciBilgileri);
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
