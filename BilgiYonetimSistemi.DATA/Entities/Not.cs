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

        public Int16? Puan { get; set; }

        public int SinavID { get; set; }

        public int OgrenciDerslerDonemlerID { get; set; }

        public virtual OgrencilerDerslerDonemler NotunOgrenciDersDonemi { get; set; }

        public virtual Sinav NotunSinavi { get; set; }
        
    }
}
