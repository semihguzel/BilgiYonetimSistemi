using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.DAL
{
    class BolumlerMapping : EntityTypeConfiguration<Bolum>
    {
        public BolumlerMapping()
        {
            ToTable("Bölümler");

            HasKey(x => x.BolumID);

            Property(x => x.BolumAdi).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);

            Property(x=>x.EgitimDili).IsRequired().HasColumnType("nvarchar").HasMaxLength(20);
            
        }
    }
}
