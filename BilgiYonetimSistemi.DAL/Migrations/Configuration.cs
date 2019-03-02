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
            if (!roleManager.RoleExists("admin"))
                roleManager.Create(new IdentityRole() { Name = "admin" });
            if (!roleManager.RoleExists("ogrenci"))
                roleManager.Create(new IdentityRole() { Name = "ogrenci" });
            if (!roleManager.RoleExists("ogretmen"))
                roleManager.Create(new IdentityRole() { Name = "ogretmen" });

            var userStore = new UserStore<Kullanici>(db);
            var userManager = new UserManager<Kullanici>(userStore);
            //Olusmuyor!!!
            var adminUser = userManager.FindByName("admin@admin.com");
            if (adminUser == null)
            {
                adminUser = new Kullanici()
                {
                    UserName = "admin",
                    Email = "admin@admin.com"
                };
                userManager.Create(adminUser, "123");
            }
            if (!userManager.IsInRole(adminUser.Id, "admin"))
                userManager.AddToRole(adminUser.Id, "admin");
        }
    }
}
