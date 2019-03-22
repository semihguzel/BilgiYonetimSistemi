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
using BilgiYonetimSistemi.DATA.DTOs;
using BilgiYonetimSistemi.DATA.Entities;
using Newtonsoft.Json;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class OgretmenController : Controller
    {
        private Context db = new Context();
        OgretmenConcrete ogretmenConcrete = new OgretmenConcrete();

        // GET: Ogretmen
        public ActionResult Index()
        {
            return View(ogretmenConcrete._ogretmenRepository.GetEntity().Where(x => x.IsActive == true).ToList());
        }

        public ActionResult Anasayfa()
        {
            var kullanici = Session["Kullanici"] as Kullanici;
            return View(ogretmenConcrete._ogretmenRepository.GetById(kullanici.Id));
        }

        // GET: Ogretmen/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogretmen ogretmen = ogretmenConcrete._ogretmenRepository.GetById(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // GET: Ogretmen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ogretmen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgretmenID,OgretmenAdi,OgretmenSoyadi,Unvan,BaslangicTarihi,AyrilisTarihi,PersonelNumarasi,Sifre")] Ogretmen ogretmen, FormCollection frm, HttpPostedFileBase file)
        {
            ogretmen.IsActive = true;
            ogretmen.BaslangicTarihi = DateTime.Parse(frm["baslangicTarihi"]);
            ogretmen.Unvan = frm["unvan"];
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
                
                ogretmen.PersonelNumarasi = "120" + ogretmenConcrete._ogretmenRepository.GetAll().Count();
                OgretmenBilgileri ogretmenBilgileri = new OgretmenBilgileri()
                {                    
                    TCNo = frm["OgretmeninBilgisi.TCNo"],
                    Fotograf = ad,                    
                };
                KullaniciIslemleri.OgretmenEkle(ogretmen, ogretmenBilgileri);
                return RedirectToAction("Index");
            }

            return View(ogretmen);
        }

        // GET: Ogretmen/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogretmen ogretmen = ogretmenConcrete._ogretmenRepository.GetById(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // POST: Ogretmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgretmenID,OgretmenAdi,OgretmenSoyadi,Unvan,PersonelNumarasi,IsActive")] Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogretmen);
        }

        // GET: Ogretmen/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogretmen ogretmen = ogretmenConcrete._ogretmenRepository.GetById(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // POST: Ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ogretmen ogretmen = db.Ogretmenler.Find(id);
            ogretmen.IsActive = false;
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

        public ActionResult OgretmenDersler()
        {
            OgretmenlerDerslerDonemlerConcrete oddc = new OgretmenlerDerslerDonemlerConcrete();
            var kullanici = Session["Kullanici"] as Kullanici;

            var ogretmen = ogretmenConcrete._ogretmenRepository.GetById(kullanici.Id);
            return View(oddc.OgretmenDersleri(kullanici.Id));
        }

        public ActionResult OgretmenDersDetay(int id,int donemId)
        {
            OgrencilerDerslerDonemlerConcrete oddc = new OgrencilerDerslerDonemlerConcrete();
            var temp = oddc.DersOgrencileri(id,donemId);
            return View(oddc.DersOgrencileri(id, donemId));
        }

        public ActionResult OgretmenDerslerNot()
        {
            OgretmenlerDerslerDonemlerConcrete oddc = new OgretmenlerDerslerDonemlerConcrete();
            var kullanici = Session["Kullanici"] as Kullanici;

            var ogretmen = ogretmenConcrete._ogretmenRepository.GetById(kullanici.Id);
            return View(oddc.OgretmenDersleri(kullanici.Id));
        }
        public ActionResult OgretmenDersNot(int id,int donemId)
        {
            ViewData["DersID"] = id;
            ViewData["DonemID"] = donemId;

            return View();
        }

        [HttpGet]
        public string OgrenciDersNotlar(int id, string sinavTipi,int donemId)
        {
            OgrencilerDerslerDonemlerConcrete oddc = new OgrencilerDerslerDonemlerConcrete();
            IEnumerable<OgrenciDersNotDTO> liste = null;
            liste = oddc.OgrenciDersNotEkleme(id, sinavTipi,donemId);
            string json = JsonConvert.SerializeObject(liste);
            return json;
        }


        
        [HttpPost]
        public void OgrenciDerseNotEkle(IEnumerable<OgrenciDersNotDTO> ogrenciDersNot, string sinavTipi)
        {
            if (ogrenciDersNot != null)
            {
                NotConcrete notConcrete = new NotConcrete();
                SinavConcrete sinavConcrete = new SinavConcrete();
                OgrencilerDerslerDonemlerConcrete oddc = new OgrencilerDerslerDonemlerConcrete();
                foreach (var item in ogrenciDersNot)
                {
                    if (item.AldigiNot != 0)
                    {
                        var ogrenciDersDonem = oddc._ogrencilerDerslerDonemlerRepository.GetById(item.OgrenciDerslerDonemlerID);
                        ogrenciDersDonem.NotGirildiMi = true;
                        oddc._ogrencilerDerslerDonemlerUnitOfWork.SaveChanges();
                        int sinavId = sinavConcrete._sinavRepository.GetEntity().FirstOrDefault(x => x.SinavTipi == sinavTipi).SinavID;
                        Not not = notConcrete._notRepository.GetEntity().FirstOrDefault(x => x.OgrenciDerslerDonemlerID == item.OgrenciDerslerDonemlerID && x.SinavID == sinavId);
                        if (not == null)
                            not = new Not();
                        not.OgrenciDerslerDonemlerID = item.OgrenciDerslerDonemlerID;
                        not.Puan = item.AldigiNot;
                        not.SinavID = sinavId;
                        if (not.NotID == 0)
                            notConcrete._notRepository.Insert(not);
                        notConcrete._notUnitOfWork.SaveChanges();
                    }
                }
                notConcrete._notUnitOfWork.Dispose();
            }
        }

    }
}
