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
            var roleStore = new RoleStore<IdentityRole>(ogrenciConcrete._dbContext);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
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
            var result = userManager.Create(kullanici, sifre);
            if (result.Succeeded)
                userManager.AddToRole(kullanici.Id, "ogrenci");
            ogrenci.OgrenciID = kullanici.Id;
            ogrenciBilgileri.OgrenciID = ogrenci.OgrenciID;
            ogrenciBilgileri.OgrenciMail = kullanici.Email;
            ogrenciConcrete._ogrenciRepository.Insert(ogrenci);
            ogrenciConcrete._ogrenciUnitOfWork.SaveChanges();
            ogrenciConcrete._ogrenciUnitOfWork.Dispose();
            ogrenciBilgileriConcrete._ogrenciBilgileriRepository.Insert(ogrenciBilgileri);
            ogrenciBilgileriConcrete._ogrenciBilgileriUnitOfWork.SaveChanges();
            ogrenciBilgileriConcrete._ogrenciBilgileriUnitOfWork.Dispose();
        }

        public static void OgretmenEkle(Ogretmen ogretmen, OgretmenBilgileri ogretmenBilgileri)
        {
            OgretmenConcrete ogretmenConcrete = new OgretmenConcrete();
            OgretmenBilgileriConcrete ogretmenBilgileriConcrete = new OgretmenBilgileriConcrete();
            var roleStore = new RoleStore<IdentityRole>(ogretmenConcrete._dbContext);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
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


            var result = userManager.Create(kullanici, sifre);
            if (result.Succeeded)
                userManager.AddToRole(kullanici.Id, "ogretmen");
            ogretmen.OgretmenID = kullanici.Id;
            ogretmenBilgileri.OgretmenID = ogretmen.OgretmenID;
            ogretmenBilgileri.OgretmenMail = kullanici.Email;
            ogretmenConcrete._ogretmenRepository.Insert(ogretmen);
            ogretmenConcrete._ogretmenUnitOfWork.SaveChanges();
            ogretmenConcrete._ogretmenUnitOfWork.Dispose();
            ogretmenBilgileriConcrete._ogretmenBilgileriRepository.Insert(ogretmenBilgileri);
            ogretmenBilgileriConcrete._ogretmenBilgileriUnitOfWork.SaveChanges();
            ogretmenBilgileriConcrete._ogretmenBilgileriUnitOfWork.Dispose();
        }

        public static void YoneticiEkle(Yonetici yonetici)
        {

            YoneticiConcrete yoneticiConcrete = new YoneticiConcrete();
            var roleStore = new RoleStore<IdentityRole>(yoneticiConcrete._dbContext);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
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
            var result = userManager.Create(kullanici, sifre);
            if (result.Succeeded)
                userManager.AddToRole(kullanici.Id, "yonetici");
            yonetici.KullaniciAdi = kullanici.UserName;
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
            {
                Array.Resize(ref donemler, donemler.Length + 1);
                donemler[i] = ogrencilerDerslerDonemler[i].DonemID;

            }
            if (donemler.Distinct().Count() > 8)
            {
                return 8;
            }
            return donemler.Distinct().Count();
        }

        public static int DonemBulma(Ogrenci ogrenci)
        {
            int donem;
            DateTime bTarih = ogrenci.KayitTarihi;
            DateTime kTarih = DateTime.Now;
            var dateSpan = ((kTarih.Year - bTarih.Year) * 12) + kTarih.Month - bTarih.Month;
            donem = (dateSpan / 6) + 1;
            return donem;

        }

        public static string DersKoduBul(string sinifDonem)
        {
            string sinif = sinifDonem.Substring(0, 1);
            string donem = sinifDonem.Substring(8, 1);
            return sinif + "0" + donem;
        }
        public static string HarfNotuGetir(OgrencilerDerslerDonemler ogrencilerDerslerDonemler, ref double toplamAgirlikli)
        {
            if (ogrencilerDerslerDonemler.OgrenciDerslerDonemlerinNotlari.Count < 4)
            {
                return "*";
            }
                int? birinciVizePuani = ogrencilerDerslerDonemler.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(x => x.SinavID == 1).Puan;
            int? ikinciVizePuani = ogrencilerDerslerDonemler.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(x => x.SinavID == 2).Puan;
            int? finalPuani = ogrencilerDerslerDonemler.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(x => x.SinavID == 3).Puan;
            double? butunlemePuani;

            double? finalliSonuc = birinciVizePuani * 0.2 + ikinciVizePuani * 0.2 + finalPuani * 0.6;


            if (ogrencilerDerslerDonemler.OgrenciDerslerDonemlerinNotlari.Count < 4)
            {
                butunlemePuani = 0;
            }
            else
            {
                butunlemePuani = ogrencilerDerslerDonemler.OgrenciDerslerDonemlerinNotlari.FirstOrDefault(x => x.SinavID == 4).Puan;
            }


            double? butluSonuc = birinciVizePuani * 0.2 + ikinciVizePuani * 0.2 + butunlemePuani * 0.6;

            if (butunlemePuani == 0)
            {
                if (finalPuani == 0)
                {
                    toplamAgirlikli += 0 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "GR";
                }
                else if (finalliSonuc < 45)
                {
                    toplamAgirlikli += 0 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "FF";
                }
                else if (finalliSonuc >= 45 && finalliSonuc < 50)
                {
                    toplamAgirlikli += 1 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "DD";
                }
                else if (finalliSonuc >= 50 && finalliSonuc < 60)
                {
                    toplamAgirlikli += 1.5 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "DC";
                }
                else if (finalliSonuc >= 60 && finalliSonuc < 70)
                {
                    toplamAgirlikli += 2 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "CC";
                }
                else if (finalliSonuc >= 70 && finalliSonuc < 80)
                {
                    toplamAgirlikli += 2.5 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "CB";
                }
                else if (finalliSonuc >= 80 && finalliSonuc < 85)
                {
                    toplamAgirlikli += 3 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "BB";
                }
                else if (finalliSonuc >= 85 && finalliSonuc < 90)
                {
                    toplamAgirlikli += 3.5 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "BA";
                }
                else if (finalliSonuc >= 90)
                {
                    toplamAgirlikli += 4 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "AA";
                }
                return "AA";
            }
            else
            {
                if (butluSonuc < 45)
                {
                    toplamAgirlikli += 0 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "FF";
                }
                else if (butluSonuc >= 45 && butluSonuc < 50)
                {
                    toplamAgirlikli += 1 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "DD";
                }
                else if (butluSonuc >= 50 && butluSonuc < 60)
                {
                    toplamAgirlikli += 1.5 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "DC";
                }
                else if (butluSonuc >= 60 && butluSonuc < 70)
                {
                    toplamAgirlikli += 2 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "CC";
                }
                else if (butluSonuc >= 70 && butluSonuc < 80)
                {
                    toplamAgirlikli += 2.5 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "CB";
                }
                else if (butluSonuc >= 80 && butluSonuc < 85)
                {
                    toplamAgirlikli += 3 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "BB";
                }
                else if (butluSonuc >= 85 && butluSonuc < 90)
                {
                    toplamAgirlikli += 3.5 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "BA";
                }
                else if (butluSonuc >= 90)
                {
                    toplamAgirlikli += 4 * ogrencilerDerslerDonemler.OgrencininDersi.DersKredisi;
                    return "AA";
                }
                return "AA";
            }

        }
    }
}
