namespace BilgiYonetimSistemi.DAL.Migrations
{
    using BilgiYonetimSistemi.DATA.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
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

            var adminUser = userManager.FindByName("yonetici");
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

            var developerUser = userManager.FindByName("developer");
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
        }
    }
}
