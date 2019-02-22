using BilgiYonetimSistemi.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DAL.Mappings
{
    public class YoneticiMapping : EntityTypeConfiguration<Yonetici>
    {
        public YoneticiMapping()
        {
            HasKey(x => x.YoneticiID);
            Property(x => x.KullaniciAdi).HasMaxLength(40);
            Property(x => x.Sifre).HasMaxLength(40);
            Property(x => x.Ad).HasMaxLength(40);
            Property(x => x.Soyad).HasMaxLength(40);
            Property(x => x.TC).HasMaxLength(11);
        }
    }
}
