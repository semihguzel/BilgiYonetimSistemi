using BilgiYonetimSistemi.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DAL
{
    class DonemlerMapping : EntityTypeConfiguration<Donem>
    {
        public DonemlerMapping()
        {
            HasKey(x => x.DonemID);
            Property(x => x.DonemYili).HasColumnType("datetime2");
        }
    }
}
