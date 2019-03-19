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
        OgrenciConcrete ogrenciConcrete;
        private Context db = new Context();
        public OgrenciController()
        {
           ogrenciConcrete = new OgrenciConcrete();
        }
        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogrenciler = db.Ogrenciler.Include(o => o.OgrencininEgitimDuzeyi).Include(o => o.OgrencininOgrenimSekli);
            return View(ogrenciler.ToList());
        }

        public ActionResult Anasayfa()
        {
            var kullanici = Session["Kullanici"] as Kullanici;
            return View(ogrenciConcrete._ogrenciRepository.GetById(kullanici.Id));
        }

        // GET: Ogrenci/Details/5
        public ActionResult Details(string id)
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
            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi");
            ViewBag.EgitimDuzeyiID = new SelectList(db.EgitimDuzeyleri, "EgitimDuzeyiID", "EgitimDuzeyTipi");
            ViewBag.OgrenimSekliID = new SelectList(db.OgrenimSekilleri, "OgrenimID", "OgrenimTipi");
            return View();
        }

        // POST: Ogrenci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrenciID,OgrenciAdi,OgrenciSoyadi,OgrenciNumarasi,KayitTarihi,MezuniyetTarihi,BolumID,OgrenimSekliID,EgitimDuzeyiID")] Ogrenci ogrenci,FormCollection frm)
        {
            if (ModelState.IsValid)
            {

                OgrenciBilgileri ogrenciBilgileri = new OgrenciBilgileri()
                {
                    Adres = frm["adres"],
                    Fotograf = frm["fotograf"],
                    MezunMu = frm["mezun"] == "on" ? true : false,
                    OgrenciID = ogrenci.OgrenciID,
                    OgrenciMail = frm["mail"],
                    Sifre = frm["sifre"],
                    TCNo = frm["tc"],
                    Telefon = frm["telefon"]
                };
                KullaniciIslemleri.OgrenciEkle(ogrenci, ogrenciBilgileri);
                return RedirectToAction("Index");
            }

            ViewBag.BolumID = new SelectList(db.Bolumler, "BolumID", "BolumAdi",ogrenci.BolumID);
            ViewBag.EgitimDuzeyiID = new SelectList(db.EgitimDuzeyleri, "EgitimDuzeyiID", "EgitimDuzeyTipi", ogrenci.EgitimDuzeyiID);
            ViewBag.OgrenimSekliID = new SelectList(db.OgrenimSekilleri, "OgrenimID", "OgrenimTipi", ogrenci.OgrenimSekliID);
            return View(ogrenci);
        }

        // GET: Ogrenci/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.OgrenciBilgileri = db.OgrenciBilgileri.FirstOrDefault(x => x.OgrenciID == id);
            ViewBag.EgitimDuzeyiID = new SelectList(db.EgitimDuzeyleri, "EgitimDuzeyiID", "EgitimDuzeyTipi", ogrenci.EgitimDuzeyiID);
            ViewBag.OgrenimSekliID = new SelectList(db.OgrenimSekilleri, "OgrenimID", "OgrenimTipi", ogrenci.OgrenimSekliID);
            return View(ogrenci);
        }

        // POST: Ogrenci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrenciID,OgrenciAdi,OgrenciSoyadi,OgrenciNumarasi,KayitTarihi,MezuniyetTarihi,BolumID,OgrenimSekliID,EgitimDuzeyiID")] Ogrenci ogrenci, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                var ogrenciBilgileri = db.OgrenciBilgileri.FirstOrDefault(x => x.OgrenciID == ogrenci.OgrenciID);
                ogrenciBilgileri.Adres = frm["OgrenciBilgisi.Adres"];
                ogrenciBilgileri.Fotograf = frm["OgrenciBilgisi.Fotograf"];
                ogrenciBilgileri.MezunMu = frm["OgrenciBilgisi.MezunMu"] == "on" ? true : false;
                ogrenciBilgileri.OgrenciMail = frm["OgrenciBilgisi.OgrenciMail"];
                ogrenciBilgileri.TCNo = frm["OgrenciBilgisi.TCNo"];
                ogrenciBilgileri.Telefon = frm["OgrenciBilgisi.Telefon"];

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EgitimDuzeyiID = new SelectList(db.EgitimDuzeyleri, "EgitimDuzeyiID", "EgitimDuzeyTipi", ogrenci.EgitimDuzeyiID);
            ViewBag.OgrenimSekliID = new SelectList(db.OgrenimSekilleri, "OgrenimID", "OgrenimTipi", ogrenci.OgrenimSekliID);
            return View(ogrenci);
        }

        // GET: Ogrenci/Delete/5
        public ActionResult Delete(string id)
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
        public ActionResult DeleteConfirmed(string id)
        {
            Ogrenci ogrenci = db.Ogrenciler.Find(id);
            db.OgrenciBilgileri.Remove(db.OgrenciBilgileri.FirstOrDefault(x => x.OgrenciID == ogrenci.OgrenciID));
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
