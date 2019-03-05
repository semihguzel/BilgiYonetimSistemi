using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilgiYonetimSistemi.BLL;
using BilgiYonetimSistemi.BLL.Repository.Concrete;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;
using BilgiYonetimSistemi.DATA.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class OgrenciController : Controller
    {
        private Context db = new Context();

        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogrenciler = db.Ogrenciler.Include(o => o.OgrencininEgitimDuzeyi).Include(o => o.OgrencininOgrenimSekli);
            return View(ogrenciler.ToList());
        }

        // GET: Ogrenci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // GET: Ogrenci/Create
        public ActionResult Create()
        {
            ViewBag.EgitimDuzeyiID = new SelectList(db.EgitimDuzeyleri, "EgitimDuzeyiID", "EgitimDuzeyTipi");
            ViewBag.OgrenimSekliID = new SelectList(db.OgrenimSekilleri, "OgrenimID", "OgrenimTipi");
            return View();
        }

        // POST: Ogrenci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrenciID,OgrenciAdi,OgrenciSoyadi,OgrenciNumarasi,KayitTarihi,MezuniyetTarihi,BolumID,OgrenimSekliID,EgitimDuzeyiID")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                KullaniciIslemleri.OgrenciEkle(ogrenci);
                return RedirectToAction("Index");
            }

            ViewBag.EgitimDuzeyiID = new SelectList(db.EgitimDuzeyleri, "EgitimDuzeyiID", "EgitimDuzeyTipi", ogrenci.EgitimDuzeyiID);
            ViewBag.OgrenimSekliID = new SelectList(db.OgrenimSekilleri, "OgrenimID", "OgrenimTipi", ogrenci.OgrenimSekliID);
            return View(ogrenci);
        }

        // GET: Ogrenci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            ViewBag.EgitimDuzeyiID = new SelectList(db.EgitimDuzeyleri, "EgitimDuzeyiID", "EgitimDuzeyTipi", ogrenci.EgitimDuzeyiID);
            ViewBag.OgrenimSekliID = new SelectList(db.OgrenimSekilleri, "OgrenimID", "OgrenimTipi", ogrenci.OgrenimSekliID);
            return View(ogrenci);
        }

        // POST: Ogrenci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrenciID,OgrenciAdi,OgrenciSoyadi,OgrenciNumarasi,KayitTarihi,MezuniyetTarihi,BolumID,OgrenimSekliID,EgitimDuzeyiID")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EgitimDuzeyiID = new SelectList(db.EgitimDuzeyleri, "EgitimDuzeyiID", "EgitimDuzeyTipi", ogrenci.EgitimDuzeyiID);
            ViewBag.OgrenimSekliID = new SelectList(db.OgrenimSekilleri, "OgrenimID", "OgrenimTipi", ogrenci.OgrenimSekliID);
            return View(ogrenci);
        }

        // GET: Ogrenci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // POST: Ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            db.Ogrenciler.Remove(ogrenci);
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
