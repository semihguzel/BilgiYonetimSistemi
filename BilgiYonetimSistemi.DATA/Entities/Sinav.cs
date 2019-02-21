using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class Sinav
    {
        public int SinavID { get; set; }

        public string SinavTipi { get; set; } //vize, final, büt.
        
        public virtual List<Not> SinavinNotlari { get; set; }
    }
}
