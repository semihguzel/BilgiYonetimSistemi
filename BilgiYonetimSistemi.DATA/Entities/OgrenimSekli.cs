using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class OgrenimSekli
    {
        public int OgrenimID { get; set; }

        public string OgrenimTipi { get; set; }

        public List<Ogrenci> OgrenimSeklininOgrencileri { get; set; }

    }
}
