using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA
{
   public class Not
    {
        public int NotID { get; set; }

        public int SinavID { get; set; }

        public string Puan { get; set; }

        public int OgrencilerDerslerID { get; set; } 

        public virtual List<OgrencilerDerslerDonemler> NotunOgrenciDersleri { get; set; }

        public virtual List<Sinav> NotunSinavlari { get; set; }
    }
}
