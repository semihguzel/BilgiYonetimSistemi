using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class Fakulte
    {
        public int FakulteID { get; set; }

        public string FakulteAdi { get; set; }

        public virtual List<FakulteBolumler> FakulteninBolumleri { get; set; } // fakülte bölüm ilişkisi kuruldu.
        
    }
}
