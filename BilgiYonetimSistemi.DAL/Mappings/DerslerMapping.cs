using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.DAL
{
   public class DerslerMapping: EntityTypeConfiguration<Ders>
    {
        public DerslerMapping()
        {
            ToTable("Dersler");

            HasKey(x => x.DersID);

            Property(x => x.DersAdi).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);

            Property(x => x.DersKodu).IsRequired().HasColumnType("nvarchar").HasMaxLength(20);

            Property(x => x.DersKredisi).IsRequired();

           
        }
    }
}
