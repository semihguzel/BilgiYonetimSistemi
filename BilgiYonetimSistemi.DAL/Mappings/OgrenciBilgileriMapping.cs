using BilgiYonetimSistemi.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DAL
{
    class OgrenciBilgileriMapping: EntityTypeConfiguration<OgrenciBilgileri>
    {
        public OgrenciBilgileriMapping()
        {
            ToTable("Öğrenci Bilgileri");
            HasKey(x => x.OgrenciID);
            Property(x => x.TCNo).HasColumnType("nvarchar").HasMaxLength(11).IsRequired();
            Property(x => x.Adres).HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.Fotograf).HasColumnType("nvarchar");
            Property(x => x.OgrenciMail).HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Telefon).HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.MezunMu).IsRequired();
          
        }
    }
}
