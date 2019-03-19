using BilgiYonetimSistemi.BLL;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class TranskriptController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var kullanici = Session["Kullanici"] as DATA.Entities.Kullanici; //online kullanıcının idsini çekmek için..
            List<OgrencilerDerslerDonemler> ogrencilerDerslerDonemler = db.OgrencilerDersler.Where(x => x.OgrenciID == kullanici.Id).ToList(); //öğrencinin aldığı bütün öğrencidersdönemler geliyor
            ViewBag.OgrencininDonemSayisi = KullaniciIslemleri.DonemSayisiniVer(ogrencilerDerslerDonemler) + 1; //öğrencinin okuduğu dönem sayısı en fazla 8 olacak şekilde geliyor
            ViewBag.BolumlerDersler = db.BolumlerDersler.Where(x => x.BolumID == kullanici.Ogrenci.OgrencininFakulteBolumu.BolumID).ToList(); //bölüme göre bölümders gönderiliyor
            return View(ogrencilerDerslerDonemler);
        }
    }
}