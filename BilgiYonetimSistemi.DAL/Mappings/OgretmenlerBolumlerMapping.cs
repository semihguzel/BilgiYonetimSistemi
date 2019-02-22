using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;
namespace BilgiYonetimSistemi.DAL
{
    class OgretmenlerBolumlerMapping : EntityTypeConfiguration<OgretmenlerBolumler>
    {
        public OgretmenlerBolumlerMapping()
        {
            HasKey(x => x.OgretmenlerBolumlerID);

            HasRequired(x => x.OgretmeninBolumu).WithMany(x => x.BolumunOgretmenleri).HasForeignKey(x => x.BolumID);
            HasRequired(x => x.BolumunOgretmeni).WithMany(x => x.OgretmeninBolumleri).HasForeignKey(x => x.OgretmenID);
        }
    }
}
