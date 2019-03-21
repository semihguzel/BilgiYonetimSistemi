using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        OgrenciBilgileriConcrete ogrenciBilgileriConcrete;
        FakulteBolumlerConcrete fakulteBolumlerConcrete;
        private Context db = new Context();
        public OgrenciController()
        {
            ogrenciConcrete = new OgrenciConcrete();
            ogrenciBilgileriConcrete = new OgrenciBilgileriConcrete();
            fakulteBolumlerConcrete = new FakulteBolumlerConcrete();
        }
        // GET: Ogrenci
        public ActionResult Index()
        {
            return View(ogrenciConcrete._ogrenciRepository.GetAll());
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
            Ogrenci ogrenci = ogrenciConcrete._ogrenciRepository.GetById(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        // GET: Ogrenci/Create
        public ActionResult Create()
        {
            ViewBag.Bolum = fakulteBolumlerConcrete._fakulteBolumlerRepository.GetAll();
            ViewBag.EgitimDuzeyiID = new SelectList(db.EgitimDuzeyleri, "EgitimDuzeyiID", "EgitimDuzeyTipi");
            ViewBag.OgrenimSekliID = new SelectList(db.OgrenimSekilleri, "OgrenimID", "OgrenimTipi");
            return View();
        }

        // POST: Ogrenci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrenciID,OgrenciAdi,OgrenciSoyadi,OgrenciNumarasi,KayitTarihi,MezuniyetTarihi,FakulteBolumlerID,OgrencininFakulteBolumu,OgrenimSekliID,EgitimDuzeyiID")] Ogrenci ogrenci, FormCollection frm, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string ad = "";
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        if (Path.GetExtension(file.FileName).ToLower() == ".jpg" || Path.GetExtension(file.FileName).ToLower() == ".png" || Path.GetExtension(file.FileName).ToLower() == ".gif" || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                        {
                            ad = Guid.NewGuid() + Path.GetExtension(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/images"), ad);
                            file.SaveAs(path);
                        }
                    }
                }


                ogrenci.KayitTarihi = DateTime.Parse(frm["kayitTarihi"]);
                ogrenci.FakulteBolumlerID = int.Parse(frm["bolumId"]);
                int sayi = ogrenciConcrete._ogrenciRepository.GetEntity().Where(x => x.FakulteBolumlerID == ogrenci.FakulteBolumlerID).Count() + 1;
                FakulteBolumler fakulteBolumler = fakulteBolumlerConcrete._fakulteBolumlerRepository.GetById(int.Parse(frm["bolumId"]));
                ogrenci.OgrenciNumarasi = ogrenci.KayitTarihi.Year.ToString() + ogrenci.EgitimDuzeyiID + ogrenci.OgrenimSekliID + fakulteBolumler.FakulteID + fakulteBolumler.BolumID + sayi;
                OgrenciBilgileri ogrenciBilgileri = new OgrenciBilgileri()
                {
                    Adres = frm["adres"],
                    Fotograf = ad,
                    OgrenciID = ogrenci.OgrenciID,
                    TCNo = frm["tc"],
                    Telefon = frm["telefon"]
                };
                KullaniciIslemleri.OgrenciEkle(ogrenci, ogrenciBilgileri);

                return RedirectToAction("Index");
            }
            
            return View(ogrenci);
        }

        // GET: Ogrenci/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = ogrenciConcrete._ogrenciRepository.GetById(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgrenciBilgileri = ogrenciBilgileriConcrete._ogrenciBilgileriRepository.GetEntity().FirstOrDefault(x => x.OgrenciID == id);
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
                
                var ogrenciBilgileri = ogrenciBilgileriConcrete._ogrenciBilgileriRepository.GetEntity().FirstOrDefault(x => x.OgrenciID == ogrenci.OgrenciID);
                ogrenciBilgileri.Adres = frm["OgrenciBilgisi.Adres"];
                ogrenciBilgileri.Fotograf = frm["OgrenciBilgisi.Fotograf"];
                ogrenciBilgileri.MezunMu = frm["OgrenciBilgisi.MezunMu"] == "on" ? true : false;
                ogrenciBilgileri.OgrenciMail = frm["OgrenciBilgisi.OgrenciMail"];
                ogrenciBilgileri.TCNo = frm["OgrenciBilgisi.TCNo"];
                ogrenciBilgileri.Telefon = frm["OgrenciBilgisi.Telefon"];

                ogrenciConcrete._ogrenciRepository.Update(ogrenci);                
                ogrenciConcrete._ogrenciUnitOfWork.SaveChanges();
                ogrenciConcrete._ogrenciUnitOfWork.Dispose();
                ogrenciBilgileriConcrete._ogrenciBilgileriRepository.Update(ogrenciBilgileri);
                ogrenciBilgileriConcrete._ogrenciBilgileriUnitOfWork.SaveChanges();
                ogrenciBilgileriConcrete._ogrenciBilgileriUnitOfWork.Dispose();
                return RedirectToAction("Index");
            }
            
            return View(ogrenci);
        }

        // GET: Ogrenci/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = ogrenciConcrete._ogrenciRepository.GetById(id);
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
            Ogrenci ogrenci = ogrenciConcrete._ogrenciRepository.GetById(id);
            OgrenciBilgileri ogrenciBilgileri = ogrenciBilgileriConcrete._ogrenciBilgileriRepository.GetById(id);
            ogrenci.MezuniyetTarihi = DateTime.Now;
            ogrenciBilgileri.MezunMu = true;
            ogrenciConcrete._ogrenciRepository.Update(ogrenci);
            ogrenciConcrete._ogrenciUnitOfWork.SaveChanges();
            ogrenciConcrete._ogrenciUnitOfWork.Dispose();
            ogrenciBilgileriConcrete._ogrenciBilgileriRepository.Update(ogrenciBilgileri);
            ogrenciBilgileriConcrete._ogrenciBilgileriUnitOfWork.SaveChanges();
            ogrenciBilgileriConcrete._ogrenciBilgileriUnitOfWork.Dispose();
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
