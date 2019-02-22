using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.DAL
{
   public class BolumlerDerslerMapping : EntityTypeConfiguration<BolumlerDersler>
    {
        public BolumlerDerslerMapping()
        {

            HasKey(x => x.BolumlerDerslerID);

            HasRequired(x => x.BolumunDersi).WithMany(x => x.DersinBolumleri).HasForeignKey(x => x.DersID); 
            HasRequired(x => x.DersinBolumu).WithMany(x => x.BolumDersleri).HasForeignKey(x => x.BolumID); 

            //çoka çok bağlandı ve bolumlerderslerID primary key olarak atandı.
        }
    }
}
