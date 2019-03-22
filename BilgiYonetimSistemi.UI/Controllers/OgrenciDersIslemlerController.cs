using BilgiYonetimSistemi.BLL;
using BilgiYonetimSistemi.BLL.Repository.Concrete;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;
using BilgiYonetimSistemi.DATA.DTOs;
using BilgiYonetimSistemi.DATA.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class OgrenciDersIslemlerController : Controller
    {

        Context db;
        public OgrenciDersIslemlerController()
        {
            db = new Context();
        }

        // GET: OgrenciDersIslemler
        public ActionResult DersSecme()
        {
            var kullanici = Session["Kullanici"] as Kullanici;
            var ogrenci = db.Ogrenciler.Find(kullanici.Id);

            OgrencilerDerslerDonemlerConcrete oddc = new OgrencilerDerslerDonemlerConcrete();

            bolumdersdonemlerConcrete bdc = new bolumdersdonemlerConcrete();

            DersConcrete dc = new DersConcrete();

            var tumDersler = bdc._bolumdersdonemlerRepository.GetEntity().Where(x => x.BolumID == ogrenci.OgrencininFakulteBolumu.BolumID).Select(x => x.DersID).ToList();

            var ogrencininDersleri = oddc._ogrencilerDerslerDonemlerRepository.GetEntity().Where(x => x.OgrenciID == ogrenci.OgrenciID).Select(x => x.DersID).ToList();

            var ogrencininAlmadigiDersIdler = tumDersler.Except(ogrencininDersleri);
            List<DersBilgiDTO> ogrencininAlmadigiDersler = new List<DersBilgiDTO>();
            foreach (var item in ogrencininAlmadigiDersIdler)
            {
                var ogrencininAlamadigiDers = dc._dersRepository.GetEntity().Where(x => x.DersID == item).Select(x => new DersBilgiDTO
                {
                    DersAdi = x.DersAdi,
                    DersID = x.DersID,
                    DersKodu = x.DersKodu,
                    DersKredisi = x.DersKredisi
                }).FirstOrDefault();
                ogrencininAlmadigiDersler.Add(ogrencininAlamadigiDers);
            }
            var toplamKredi = oddc._ogrencilerDerslerDonemlerRepository.GetEntity().Where(x => x.OgrenciID == ogrenci.OgrenciID && x.NotGirildiMi == false).Sum(x => x.OgrencininDersi.DersKredisi);
            foreach (var item in ogrencininDersleri)
            {
                var ogrencininAldigiDers = dc._dersRepository.GetEntity().Where(x => x.DersID == item).Select(x => new DersBilgiDTO
                {
                    DersID = x.DersID,
                    DersAdi = x.DersAdi,
                    DersKodu = x.DersKodu,
                    DersKredisi = x.DersKredisi
                }).FirstOrDefault();
                //toplamKredi += ogrencininAldigiDers.DersKredisi;
            }
            ViewBag.ToplamKredi = toplamKredi;
            return View(ogrencininAlmadigiDersler);
        }


        [HttpPost]
        public JsonResult DersSecme(ICollection<Ders> dersler)
        {
            var kullanici = Session["Kullanici"] as Kullanici;
            var ogrenci = db.Ogrenciler.Find(kullanici.Id);

            foreach (var item in dersler)
            {
                OgrencilerDerslerDonemler ogrenciDersDonem = new OgrencilerDerslerDonemler();
                ogrenciDersDonem.OgrenciID = ogrenci.OgrenciID;
                ogrenciDersDonem.DersID = item.DersID;
                ogrenciDersDonem.DonemID = db.Donemler.FirstOrDefault(x => x.DonemYili == DateTime.Now.Year.ToString()).DonemID;
                db.OgrencilerDersler.Add(ogrenciDersDonem);
                db.SaveChanges();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DerslerinListesi()
        {
            var kullanici = Session["Kullanici"] as Kullanici;
            Ogrenci ogrenci = db.Ogrenciler.Find(kullanici.Id);
            ViewBag.Ogrenci = ogrenci;

            return View();
        }


        [HttpGet]
        public string DerslerinListesiGetir(string SinifDonem)
        {
            var kullanici = Session["Kullanici"] as Kullanici;
            Ogrenci ogrenci = db.Ogrenciler.Find(kullanici.Id);
            ViewBag.Ogrenci = ogrenci;

            string dKod = KullaniciIslemleri.DersKoduBul(SinifDonem);

            List<OgrenciDersDTO> ogrencininDersNotlari = db.OgrencilerDersler.Where(x => x.OgrencininDersi.DersKodu.Substring(3, 3) == dKod && x.OgrenciID == ogrenci.OgrenciID).Select(x => new OgrenciDersDTO
            {
                DersAdi = x.OgrencininDersi.DersAdi,
                DersID = x.OgrencininDersi.DersID,
                DersKodu = x.OgrencininDersi.DersKodu,
                DersKredisi = x.OgrencininDersi.DersKredisi,
                Vize1 = x.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(y => y.NotunSinavi.SinavTipi == "Vize-1").Puan,
                Vize2 = x.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(y => y.NotunSinavi.SinavTipi == "Vize-2").Puan,
                Final = x.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(y => y.NotunSinavi.SinavTipi == "Final").Puan,
                But = x.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(y => y.NotunSinavi.SinavTipi == "But").Puan
            }).ToList();


            string json = JsonConvert.SerializeObject(ogrencininDersNotlari);
            return json;

        }
    }
}