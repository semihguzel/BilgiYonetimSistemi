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

    }
}