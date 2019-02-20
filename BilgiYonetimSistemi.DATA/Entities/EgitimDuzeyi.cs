using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
    public class EgitimDuzeyi
    {
        public int EgitimDuzeyiID { get; set; }

        public string EgitimDuzeyTipi { get; set; }

        public virtual List<Ogrenci> EgitimDuzeyininOgrencileri { get; set; }
    }
}
