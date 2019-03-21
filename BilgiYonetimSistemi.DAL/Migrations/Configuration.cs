namespace BilgiYonetimSistemi.DAL.Migrations
{
    using BilgiYonetimSistemi.DATA.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;



    internal sealed class Configuration : DbMigrationsConfiguration<BilgiYonetimSistemi.DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BilgiYonetimSistemi.DAL.Context db)
        {
            //Sýnav tipleri
            if (db.Sinavlar.ToList().Count == 0)
            {
                db.Sinavlar.Add(new DATA.Sinav() { SinavTipi = "Vize-1" });
                db.Sinavlar.Add(new DATA.Sinav() { SinavTipi = "Vize-2" });
                db.Sinavlar.Add(new DATA.Sinav() { SinavTipi = "Final" });
                db.Sinavlar.Add(new DATA.Sinav() { SinavTipi = "Büt" });
                db.SaveChanges();
            }
            //Admin - Developer eklenme kýsmý
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("yonetici"))
                roleManager.Create(new IdentityRole() { Name = "yonetici" });

            if (!roleManager.RoleExists("ogrenci"))
                roleManager.Create(new IdentityRole() { Name = "ogrenci" });

            if (!roleManager.RoleExists("ogretmen"))
                roleManager.Create(new IdentityRole() { Name = "ogretmen" });

            if (!roleManager.RoleExists("developer"))
                roleManager.Create(new IdentityRole() { Name = "developer" });

            var userStore = new UserStore<Kullanici>(db);
            var userManager = new UserManager<Kullanici>(userStore);

            var adminUser = userManager.FindByName("admin@admin.com");
            if (adminUser == null)
            {
                adminUser = new Kullanici()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };
                userManager.Create(adminUser, "Acer-1");
            }
            if (!userManager.IsInRole(adminUser.Id, "yonetici"))
                userManager.AddToRole(adminUser.Id, "yonetici");

            var developerUser = userManager.FindByName("developer@developer.com");
            if (developerUser == null)
            {
                developerUser = new Kullanici()
                {
                    UserName = "developer@developer.com",
                    Email = "developer@developer.com"
                };
                userManager.Create(developerUser, "Acer-1");
            }
            if (!userManager.IsInRole(developerUser.Id, "developer"))
                userManager.AddToRole(developerUser.Id, "developer");
            //Egitim Duzey Tipi
            if (db.EgitimDuzeyleri.ToList().Count == 0)
            {
                db.EgitimDuzeyleri.Add(new DATA.EgitimDuzeyi() { EgitimDuzeyTipi = "Lisans" });
                db.EgitimDuzeyleri.Add(new DATA.EgitimDuzeyi() { EgitimDuzeyTipi = "Ön Lisans" });
                db.EgitimDuzeyleri.Add(new DATA.EgitimDuzeyi() { EgitimDuzeyTipi = "Yüksek Lisans" });
                db.SaveChanges();
            }
            //Egitim Duzey Tipi
            if (db.OgrenimSekilleri.ToList().Count == 0)
            {
                db.OgrenimSekilleri.Add(new DATA.OgrenimSekli() { OgrenimTipi = "Örgün Öðretim" });
                db.OgrenimSekilleri.Add(new DATA.OgrenimSekli() { OgrenimTipi = "Ýkinci Öðretim" });
                db.OgrenimSekilleri.Add(new DATA.OgrenimSekli() { OgrenimTipi = "Uzaktan Eðitim" });
                db.SaveChanges();
            }
        }
    }

}

