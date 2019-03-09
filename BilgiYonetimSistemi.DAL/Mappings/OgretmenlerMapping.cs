using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;


namespace BilgiYonetimSistemi.DAL
{
    class OgretmenlerMapping : EntityTypeConfiguration<Ogretmen>
    {
        public OgretmenlerMapping()
        {
            HasKey(x => x.OgretmenID);

            Property(x => x.OgretmenAdi).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            Property(x => x.OgretmenSoyadi).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            Property(x => x.AyrilisTarihi).HasColumnType("datetime2");
            Property(x => x.BaslangicTarihi).HasColumnType("datetime2");
            Property(x => x.PersonelNumarasi).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            Property(x => x.Sifre).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            Property(x => x.Unvan).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            Property(x => x.IsActive).IsRequired();

            HasRequired(x => x.OgretmeninBilgisi).WithRequiredPrincipal(x => x.BilgininOgretmeni);

        }
    }
}
