using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.DAL
{
    class OgrencilerDerslerDonemlerMapping : EntityTypeConfiguration<OgrencilerDerslerDonemler>
    {
        public OgrencilerDerslerDonemlerMapping()
        {
            HasKey(x => x.OgrenciDerslerDonemler);

            HasRequired(x => x.OgrencininDersi).WithMany(x => x.DersinOgrencileri).HasForeignKey(x => x.DersID);

            HasRequired(x => x.DersinOgrencisi).WithMany(x => x.OgrencininDersleri).HasForeignKey(x => x.OgrenciID);

            HasRequired(x => x.OgrenciDersinDonemi).WithMany(x => x.DoneminOgrencilerDersleri).HasForeignKey(x => x.DonemID);
        }
    }
}
