using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;


namespace BilgiYonetimSistemi.DAL
{
    class OgretmenlerDerslerDonemlerMapping : EntityTypeConfiguration<OgretmenlerDerslerDonemler>
    {
        public OgretmenlerDerslerDonemlerMapping()
        {
            HasKey(x => x.OgretmenlerDerslerID);

            HasRequired(x => x.DersinOgretmeni).WithMany(x => x.OgretmeninDersleri).HasForeignKey(x=>x.OgretmenID);

            HasRequired(x => x.OgretmeninDersi).WithMany(x => x.DersinOgretmenleri).HasForeignKey(x=>x.DersID);

            HasRequired(x => x.OgretmenDersinDonemi).WithMany(x =>x.DoneminOgretmenlerDersleri).HasForeignKey(x => x.DonemID);
        }
    }
}
