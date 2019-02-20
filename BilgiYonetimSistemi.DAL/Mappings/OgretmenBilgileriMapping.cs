using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.DAL
{
    class OgretmenBilgileriMapping : EntityTypeConfiguration<OgretmenBilgileri>
    {
        public OgretmenBilgileriMapping()
        {
            HasKey(x => x.OgretmenID);

            Property(x => x.Fotograf).HasColumnType("nvarchar");

            Property(x => x.OgretmenMail).HasColumnType("nvarchar").HasMaxLength(30);

            Property(x => x.TCNo).HasColumnType("nvarchar").HasMaxLength(11);

          
        }
    }
}
