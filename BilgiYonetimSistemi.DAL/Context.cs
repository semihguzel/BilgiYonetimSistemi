using BilgiYonetimSistemi.DAL.Mappings;
using BilgiYonetimSistemi.DATA;
using BilgiYonetimSistemi.DATA.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DAL
{
    public class Context : IdentityDbContext<Kullanici>
    {
        public static Context Create()
        {
            return new Context();
        }

        public Context() : base(@"server = .; database = BilgiYonetimSistemiDb; uid = sa; pwd = 123")
        {
        }
        //aşağıda çoğullaştırma işlemleri doğaçlama yapıldı.
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<BolumlerDersler> BolumlerDersler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Donem> Donemler { get; set; }
        public DbSet<EgitimDuzeyi> EgitimDuzeyleri { get; set; }
        public DbSet<Fakulte> Fakulteler { get; set; }
        public DbSet<FakulteBolumler> FakulteBolumler { get; set; }
        public DbSet<Not> Notlar { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<OgrenciBilgileri> OgrenciBilgileri { get; set; }
        public DbSet<OgrencilerBolumler> OgrencilerBolumler { get; set; }
        public DbSet<OgrencilerDerslerDonemler> OgrencilerDersler { get; set; }
        public DbSet<OgrenimSekli> OgrenimSekilleri { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<OgretmenBilgileri> OgretmenBilgileri { get; set; }
        public DbSet<OgretmenlerBolumler> OgretmenlerBolumler { get; set; }
        public DbSet<OgretmenlerDerslerDonemler> OgretmenlerDersler { get; set; }
        public DbSet<Sinav> Sinavlar { get; set; }
        public DbSet<Yonetici> Yoneticiler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BolumlerDerslerMapping());
            modelBuilder.Configurations.Add(new BolumlerMapping());
            modelBuilder.Configurations.Add(new DerslerMapping());
            modelBuilder.Configurations.Add(new DonemlerMapping());
            modelBuilder.Configurations.Add(new EgitimDuzeyiMapping());
            modelBuilder.Configurations.Add(new FakulteBolumlerMapping());
            modelBuilder.Configurations.Add(new FakulteMapping());
            modelBuilder.Configurations.Add(new NotlarMapping());
            modelBuilder.Configurations.Add(new OgrenciBilgileriMapping());
            modelBuilder.Configurations.Add(new OgrencilerBolumlerMapping());
            modelBuilder.Configurations.Add(new OgrencilerDerslerDonemlerMapping());
            modelBuilder.Configurations.Add(new OgrencilerMapping());
            modelBuilder.Configurations.Add(new OgrenimSekliMapping());
            modelBuilder.Configurations.Add(new OgretmenBilgileriMapping());
            modelBuilder.Configurations.Add(new OgretmenlerBolumlerMapping());
            modelBuilder.Configurations.Add(new OgretmenlerDerslerDonemlerMapping());
            modelBuilder.Configurations.Add(new OgretmenlerMapping());
            modelBuilder.Configurations.Add(new SinavlarMapping());
            modelBuilder.Configurations.Add(new YoneticiMapping());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
