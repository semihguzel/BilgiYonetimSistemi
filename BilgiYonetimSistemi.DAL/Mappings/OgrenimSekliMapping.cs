using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.DAL
{
    class OgrenimSekliMapping : EntityTypeConfiguration<OgrenimSekli>
    {
        public OgrenimSekliMapping()
        {
            HasKey(x => x.OgrenimID);

            Property(x => x.OgrenimTipi).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);

        }
    }
}
