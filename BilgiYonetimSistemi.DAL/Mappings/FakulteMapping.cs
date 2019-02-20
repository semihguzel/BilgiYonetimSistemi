using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilgiYonetimSistemi.DATA;

namespace BilgiYonetimSistemi.DAL
{
    class FakulteMapping : EntityTypeConfiguration<Fakulte>
    {
        public FakulteMapping()
        {
            HasKey(x => x.FakulteID);

            Property(x => x.FakulteAdi).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
        }
    }
}
