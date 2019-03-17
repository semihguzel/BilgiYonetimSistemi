using BilgiYonetimSistemi.BLL.Repository.Concrete;
using BilgiYonetimSistemi.DAL;
using BilgiYonetimSistemi.DATA;
using BilgiYonetimSistemi.DATA.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.BLL
{
    public static class KullaniciIslemleri
    {


        public static void OgrenciEkle(Ogrenci ogrenci, OgrenciBilgileri ogrenciBilgileri)
        {
            OgrenciConcrete ogrenciConcrete = new OgrenciConcrete();
            OgrenciBilgileriConcrete ogrenciBilgileriConcrete = new OgrenciBilgileriConcrete();
            var userStore = new UserStore<Kullanici>(ogrenciConcrete._dbContext);
            var userManager = new UserManager<Kullanici>(userStore);
            var kullanici = userManager.FindByName((ogrenci.OgrenciAdi.ToLower() + ogrenci.OgrenciSoyadi.ToLower()));
            if (kullanici == null)
            {
                kullanici = new Kullanici()
                {
                    UserName = ogrenci.OgrenciAdi.ToLower() + ogrenci.OgrenciSoyadi.ToLower(),
                    Email = ogrenci.OgrenciAdi.ToLower() + ogrenci.OgrenciSoyadi.ToLower() + "@uni.edu.tr"
                };
            }
            else
            {
                int sayi = 0;
                while (kullanici != null)
                {
                    sayi++;
                    kullanici = userManager.FindByName((ogrenci.OgrenciAdi.ToLower() + ogrenci.OgrenciSoyadi.ToLower() + sayi));
                }
                kullanici = new Kullanici()
                {
                    UserName = ogrenci.OgrenciAdi.ToLower() + ogrenci.OgrenciSoyadi.ToLower() + sayi,
                    Email = ogrenci.OgrenciAdi.ToLower() + ogrenci.OgrenciSoyadi.ToLower() + sayi + "@uni.edu.tr"
                };
            }
            //Yapicalak: Sifre kisminda TC Ogrenci kismina alinacak, asagidaki ornek gibi sifre girisi yapilacak.
            //Muhammed Talha Balci
            //Mb123717238192739.
            string sifre = ogrenci.OgrenciAdi.Substring(0, 1).ToUpper() + ogrenci.OgrenciAdi.Substring(1) + ogrenci.KayitTarihi.Date.Year + ".";
            userManager.Create(kullanici, sifre);
            userManager.AddToRole(kullanici.Id, "ogrenci");

            ogrenci.OgrenciID = kullanici.Id;
            ogrenciBilgileri.OgrenciID = ogrenci.OgrenciID;
            ogrenciConcrete._ogrenciRepository.Insert(ogrenci);
            ogrenciConcrete._ogrenciUnitOfWork.SaveChanges();
            ogrenciConcrete._ogrenciUnitOfWork.Dispose();
            ogrenciBilgileriConcrete._ogrenciBilgileriRepository.Insert(ogrenciBilgileri);
            ogrenciBilgileriConcrete._ogrenciBilgileriUnitOfWork.SaveChanges();
            ogrenciBilgileriConcrete._ogrenciBilgileriUnitOfWork.Dispose();
        }

        public static void OgretmenEkle(Ogretmen ogretmen)
        {
            OgretmenConcrete ogretmenConcrete = new OgretmenConcrete();
            var userStore = new UserStore<Kullanici>(ogretmenConcrete._dbContext);
            var userManager = new UserManager<Kullanici>(userStore);
            var kullanici = userManager.FindByName((ogretmen.OgretmenAdi.ToLower() + ogretmen.OgretmenSoyadi.ToLower()));
            if (kullanici == null)
            {
                kullanici = new Kullanici()
                {
                    UserName = ogretmen.OgretmenAdi.ToLower() + ogretmen.OgretmenSoyadi.ToLower(),
                    Email = ogretmen.OgretmenAdi.ToLower() + ogretmen.OgretmenSoyadi.ToLower() + "@uni.edu.tr"
                };
            }
            else
            {
                int sayi = 0;
                while (kullanici != null)
                {
                    sayi++;
                    kullanici = userManager.FindByName((ogretmen.OgretmenAdi.ToLower() + ogretmen.OgretmenSoyadi.ToLower() + sayi));
                }
                kullanici = new Kullanici()
                {
                    UserName = ogretmen.OgretmenAdi.ToLower() + ogretmen.OgretmenSoyadi.ToLower() + sayi,
                    Email = ogretmen.OgretmenAdi.ToLower() + ogretmen.OgretmenSoyadi.ToLower() + sayi + "@uni.edu.tr"
                };
            }
            //Yapicalak: Sifre kisminda TC Ogrenci kismina alinacak, asagidaki ornek gibi sifre girisi yapilacak.
            //Muhammed Talha Balci
            //Mb123717238192739.
            string sifre = ogretmen.OgretmenAdi.Substring(0, 1).ToUpper() + ogretmen.OgretmenAdi.Substring(1) + ogretmen.BaslangicTarihi.Date.Year + ".";
            userManager.Create(kullanici, sifre);
            userManager.AddToRole(kullanici.Id, "ogretmen");

            ogretmen.OgretmenID = kullanici.Id;
            ogretmenConcrete._ogretmenRepository.Insert(ogretmen);
            ogretmenConcrete._ogretmenUnitOfWork.SaveChanges();
            ogretmenConcrete._ogretmenUnitOfWork.Dispose();
        }

        public static void YoneticiEkle(Yonetici yonetici)
        {

            YoneticiConcrete yoneticiConcrete = new YoneticiConcrete();
            var userStore = new UserStore<Kullanici>(yoneticiConcrete._dbContext);
            var userManager = new UserManager<Kullanici>(userStore);
            var kullanici = userManager.FindByName((yonetici.Ad.ToLower() + yonetici.Soyad.ToLower()));
            if (kullanici == null)
            {
                kullanici = new Kullanici()
                {
                    UserName = yonetici.Ad.ToLower() + yonetici.Soyad.ToLower(),
                    Email = yonetici.Ad.ToLower() + yonetici.Soyad.ToLower() + "@uni.edu.tr"
                };
            }
            else
            {
                int sayi = 0;
                while (kullanici != null)
                {
                    sayi++;
                    kullanici = userManager.FindByName((yonetici.Ad.ToLower() + yonetici.Soyad.ToLower() + sayi));
                }
                kullanici = new Kullanici()
                {
                    UserName = yonetici.Ad.ToLower() + yonetici.Soyad.ToLower() + sayi,
                    Email = yonetici.Ad.ToLower() + yonetici.Soyad.ToLower() + sayi + "@uni.edu.tr"
                };
            }
            //Yapicalak: Sifre kisminda TC Ogrenci kismina alinacak, asagidaki ornek gibi sifre girisi yapilacak.
            //Muhammed Talha Balci
            //Mb123717238192739.
            string sifre = yonetici.Ad.Substring(0, 1).ToUpper() + yonetici.Soyad.Substring(0, 1).ToLower() + yonetici.TC + ".";
            userManager.Create(kullanici, sifre);
            userManager.AddToRole(kullanici.Id, "yonetici");

            yonetici.YoneticiID = kullanici.Id;
            yoneticiConcrete._yoneticiRepository.Insert(yonetici);
            yoneticiConcrete._yoneticiUnitOfWork.SaveChanges();
            yoneticiConcrete._yoneticiUnitOfWork.Dispose();



        }

        public static bool RolGecerliMi(Kullanici kullanici, string rolAdi)
        {
            Context db = new Context();
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var role = roleManager.FindByName(rolAdi);
            if (role != null && kullanici.Roles.First().RoleId == role.Id)
                return true;
            else
                return false;
        }
        

        public static int DonemSayisiniVer(List<OgrencilerDerslerDonemler> ogrencilerDerslerDonemler)
        {
            int[] donemler = new int[0];
            for (int i = 0; i < ogrencilerDerslerDonemler.Count; i++)
            {Array.Resize(ref donemler, donemler.Length + 1);
                donemler[i] = ogrencilerDerslerDonemler[i].DonemID;
                
            }
            if (donemler.Distinct().Count() >8)
            {
                return 8;
            }
            return donemler.Distinct().Count();
        }
    }
}
