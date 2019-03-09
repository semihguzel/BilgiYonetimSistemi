using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgiYonetimSistemi.UI.Controllers
{
    public class HomeController : Controller
    {
        //bence elle yazalim ama gorev paylasimi yapmak lazim 1 2.si de ekleme silme guncellemeyi su repository yapisiyla herkes yazabilecek mi
        //ben sadece zaten admindeki ogrenci ekleme falan onu yapayim onun ustunden digerlerini yapmak kolay olur
        //sol taraf kesin olucak zaten
        //onu belirlemedik mi
        //en son yazmislardi seneryo olayini
        //orda ne yaziyorsa o zaten
        //ekleme - listeleme - guncelleme- silme hepsi icin soldan butona basinca 
        //bak simdi seneryoyu soyluyorum ogrenci butonuna tiklayinca
        //ogrencilerin listesi olan sayfaya gidecek. her ogrenci satirinin saginda guncelleme - silme - detay butonlari olucak.
        //orda bi dersin - sinifin secimini yapabiliriz su dersteki su ogrenci gibi
        //dusunuyorum abi 1 sn
        //scaffold yapisiyla bu olmaz zaten bizim bircok tabloyla isimiz var ogrenci eklemede bunlari sectirip hepsini bir kayit yaptirmamiz lazim
        //modeli veriyorsun o model icin crud islemi yapisi olusturuyor. Ogrenci tablosunu veriyosun onun icin crud islemi yapicak hazir metodlari yaziyor.
        //Create Read Update Delete kendin koyarsin tabi ama suan sifirdan elle yazmak en mantiklisi :D
        // RenderBody icine view atiyoruz bu kadar
        //bakarim sagol
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            string email = frm["Email"];
            string sifre = frm["Password"];

            Context db = new Context();

            var userStore = new UserStore<Kullanici>(db);
            var userManager = new UserManager<Kullanici>(userStore);

            var kullanici = userManager.FindByEmail(email);
            if (kullanici == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var roller = userManager.GetRoles(kullanici.Id);
                Session["KullaniciRol"] = roller.First();

            }

            return View();
        }

    }
}