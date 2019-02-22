using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.DAL
{
    class OgrencilerBolumlerMapping : EntityTypeConfiguration<OgrencilerBolumler>
    {
        public OgrencilerBolumlerMapping()
        {
            HasKey(x => x.OgrencilerBolumlerID);

            HasRequired(x => x.BolumunOgrencisi).WithMany(x => x.OgrencininBolumleri).HasForeignKey(x => x.OgrenciID);
            HasRequired(x => x.OgrencininBolumu).WithMany(x => x.BolumunOgrencileri).HasForeignKey(x => x.BolumID);
        }
    }
}
