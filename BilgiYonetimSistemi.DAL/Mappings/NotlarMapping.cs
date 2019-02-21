using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;


namespace BilgiYonetimSistemi.DAL
{
    class NotlarMapping : EntityTypeConfiguration<Not>
    {
        public NotlarMapping()
        {
            HasKey(x => x.NotID);

            Property(x => x.Puan).IsRequired();

            HasRequired(x => x.NotunOgrenciDersDonemi).WithMany(x => x.OgrenciDerslerDonemlerinNotlari).HasForeignKey(x => x.OgrenciDerslerDonemlerID);

            HasRequired(x => x.NotunSinavi).WithMany(x => x.SinavinNotlari).HasForeignKey(x => x.SinavID);
        }
    }
}
