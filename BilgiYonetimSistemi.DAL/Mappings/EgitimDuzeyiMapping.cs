using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;


namespace BilgiYonetimSistemi.DAL
{
    class EgitimDuzeyiMapping : EntityTypeConfiguration<EgitimDuzeyi>
    {
        public EgitimDuzeyiMapping()
        {
            HasKey(x => x.EgitimDuzeyiID);

            Property(x => x.EgitimDuzeyTipi).HasColumnType("nvarchar").HasMaxLength(20);

        }
    }
}
