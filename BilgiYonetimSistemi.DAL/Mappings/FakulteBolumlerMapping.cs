using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;


namespace BilgiYonetimSistemi.DAL
{
    class FakulteBolumlerMapping : EntityTypeConfiguration<FakulteBolumler>
    {
        public FakulteBolumlerMapping()
        {
            HasKey(x => x.FakulteBolumlerID); //primary key olarak atandı.

            HasRequired(x => x.BolumunFakultesi).WithMany(x => x.FakulteninBolumleri).HasForeignKey(x=>x.BolumID);
            HasRequired(x => x.FakulteninBolumu).WithMany(x => x.BolumunFakulteleri).HasForeignKey(x=>x.FakulteID);  //çoka çok ilişki sağlandı.
        }
    }
}
