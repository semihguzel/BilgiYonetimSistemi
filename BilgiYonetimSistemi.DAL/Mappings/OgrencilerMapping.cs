using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;


namespace BilgiYonetimSistemi.DAL
{
    class OgrencilerMapping : EntityTypeConfiguration<Ogrenci>
    {
        public OgrencilerMapping()
        {
            ToTable("Öğrenciler");
            HasKey(x => x.OgrenciID);

            Property(x => x.KayitTarihi).IsRequired().HasColumnType("datetime2");
            Property(x => x.MezuniyetTarihi).HasColumnType("datetime2");
            Property(x => x.OgrenciAdi).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.OgrenciNumarasi).IsRequired().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.OgrenciSoyadi).IsRequired().HasColumnType("nvarchar").HasMaxLength(20);

            HasRequired(x => x.OgrencininOgrenimSekli).WithMany(x => x.OgrenimSeklininOgrencileri).HasForeignKey(x=>x.OgrenimSekliID);

            HasRequired(x => x.OgrencininEgitimDuzeyi).WithMany(x => x.EgitimDuzeyininOgrencileri).HasForeignKey(x => x.EgitimDuzeyiID);

            HasRequired(x => x.OgrenciBilgisi).WithRequiredPrincipal(x => x.BilgininOgrencisi);

        }
    }
}
