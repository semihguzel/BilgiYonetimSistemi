using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.DAL
{
    class SinavlarMapping: EntityTypeConfiguration<Sinav>
    {
        public SinavlarMapping()
        {
            ToTable("Sınavlar");
            HasKey(x => x.SinavID);
            Property(x => x.SinavTipi).IsRequired().HasColumnType("nvarchar").HasMaxLength(10);

            HasRequired(x => x.SinavinNotu).WithMany(x => x.NotunSinavlari).HasForeignKey(x => x.NotID);
        }
    }
}
